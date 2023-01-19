using System;
using AuthTemplate.Controls;
using AuthTemplate.Handlers;
using AuthTemplate.Services;
using AuthTemplate.Models;

namespace AuthTemplate.ViewModels.AccountManagement
{
    [QueryProperty(nameof(_token), "token")]
    public partial class ResetPasswordPageViewModel : BaseViewModel
	{

		[ObservableProperty]
		private string _newPassword;

		[ObservableProperty]
		private string _confirmNewPassword;

        // TODO: Figure out how to get token from url string
        // https://learn.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/navigation?WT.mc_id=shelldata-blog-jamont#process-navigation-data-using-query-property-attributes
        [ObservableProperty]
		private string _token;

		private IAccountManagementService _accountManagementService;

		public ResetPasswordPageViewModel(IAccountManagementService accountManagementService)
		{
			_accountManagementService = accountManagementService;
		}

		async void ResetPassword()
		{
			ResetPasswordRequest request = new ResetPasswordRequest
			{
				Token = Token,
				NewPassword = NewPassword,
				ConfirmNewPassword = ConfirmNewPassword
			};

			bool successfulReset = await _accountManagementService.ResetPassword(request);

			if(successfulReset)
			{
				// alert that password was successfully reset
				// redirect to dashboard to login
			}
			else
			{
				// alert that the password was not reset correctly and suggest they try again
			}
		}
	}
}

