using System;
using AuthTemplate.Models;
namespace AuthTemplate.Services
{
	public interface ILoginService
	{
		Task<AuthResponse> Authenticate(LoginRequest loginRequest);

	}
}

