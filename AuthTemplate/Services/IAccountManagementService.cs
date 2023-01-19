using System;
using AuthTemplate.Models;
namespace AuthTemplate.Services
{
	public interface IAccountManagementService
	{
		Task<bool> ResetPassword(ResetPasswordRequest resetPasswordRequest);
	}
}

