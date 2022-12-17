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
						Email = Email
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
    }
}

