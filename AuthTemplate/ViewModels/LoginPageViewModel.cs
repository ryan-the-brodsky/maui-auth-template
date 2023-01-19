using AuthTemplate.Views.Dashboard;
using AuthTemplate.Views.Startup;
using AuthTemplate.Models;
using AuthTemplate.Controls;
using Newtonsoft.Json;
using AuthTemplate.Services;

namespace AuthTemplate.ViewModels
{
	public partial class LoginPageViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string _email;

		[ObservableProperty]
		private string _password;

		private readonly ILoginService _loginService;

		public LoginPageViewModel(ILoginService loginService)
		{
			_loginService = loginService;
		}

		[ICommand]
		async void Login()
		{
			if(!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
			{

				//api call
				AuthResponse response = await _loginService.Authenticate(new LoginRequest
				{
					Email = Email,
					Password = Password
				});

				if (response.IsAuthSuccessful)
				{
					var userDetails = new UserInfo()
					{
						Email = Email,
						Token = response.Token,
						FirstName = response.FirstName,
						LastName = response.LastName
					};

					if (Preferences.ContainsKey(nameof(App.UserDetails)))
					{
						Preferences.Remove(nameof(App.UserDetails));
					}

					string userDetailStr = JsonConvert.SerializeObject(userDetails);
					Preferences.Set(nameof(App.UserDetails), userDetailStr);
					App.UserDetails = userDetails;
					AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
					await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                }
				else
				{
					// Login was unsuccessful
					await AppShell.Current.DisplayAlert(response.ErrorMessage, response.ErrorMessage, "OK");
				}

				

            }
        }

        [ICommand]
        async void GoToRegistrationPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
        }

		[ICommand]
		async void GoogleAuth()
		{
            try
            {
                WebAuthenticatorResult result = null;
                    result = await WebAuthenticator.Default.AuthenticateAsync(
                        new Uri("https://localhost:7043/api/accounts/google-auth"),
                        new Uri("authtemplate://google-auth-success"));

                    string accessToken = result?.AccessToken;

                    // Do something with the token
                var authToken = string.Empty;

                if (result.Properties.TryGetValue("name", out string name) && !string.IsNullOrEmpty(name))
                    authToken += $"Name: {name}{Environment.NewLine}";

                if (result.Properties.TryGetValue("email", out string email) && !string.IsNullOrEmpty(email))
                    authToken += $"Email: {email}{Environment.NewLine}";

                // Note that Apple Sign In has an IdToken and not an AccessToken
                authToken += result?.AccessToken ?? result?.IdToken;

            }
            catch (TaskCanceledException e)
            {
                // Use stopped auth
            }
        }
    }
}

