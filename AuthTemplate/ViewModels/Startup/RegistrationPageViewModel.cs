using AuthTemplate.Views.Dashboard;
using AuthTemplate.Views.Startup;
using AuthTemplate.Models;
using AuthTemplate.Controls;
using Newtonsoft.Json;
using AuthTemplate.Services;
namespace AuthTemplate.ViewModels.Startup
{
	public partial class RegistrationPageViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string _firstName;

		[ObservableProperty]
		private string _lastName;

		[ObservableProperty]
		private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _confirmPassword;

		private IRegistrationService _registrationService;

        public RegistrationPageViewModel(IRegistrationService registrationService)
		{
			_registrationService = registrationService;
		}

		[ICommand]
		async void Register()
		{
			List<string> frontEndErrors = new List<string>();
			if(Password != ConfirmPassword)
			{
				frontEndErrors.Add("Password and Confirmation Password Must Match.");
			}
			if(!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password)
				&& !string.IsNullOrWhiteSpace(ConfirmPassword) && !string.IsNullOrWhiteSpace(FirstName)
				&& !string.IsNullOrWhiteSpace(LastName))
			{
				RegistrationRequest request = new RegistrationRequest
				{
					Email = Email,
					Password = Password,
					ConfirmPassword = ConfirmPassword,
					FirstName = FirstName,
					LastName = LastName
				};
				AuthResponse response = await _registrationService.Register(request);
				if(response.IsAuthSuccessful)
				{
                    var userDetails = new UserInfo()
                    {
                        Email = Email,
                        FirstName = FirstName,
                        LastName = LastName
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
					// use response.ErrorMessages as a List in the future
                    await AppShell.Current.DisplayAlert("Unsuccessful Registration", "Unsuccessful Registration", "OK");

                }
            }
		}
	}
}

