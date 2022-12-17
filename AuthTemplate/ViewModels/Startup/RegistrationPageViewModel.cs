using System;
using AuthTemplate.Services;
using AuthTemplate.Models;
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
			}
		}
	}
}

