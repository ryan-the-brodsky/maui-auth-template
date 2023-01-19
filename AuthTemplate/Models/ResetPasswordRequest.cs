using System;
namespace AuthTemplate.Models
{
	public class ResetPasswordRequest
	{
		public string NewPassword;

		public string ConfirmNewPassword;

		public string Token;
	}
}

