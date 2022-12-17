using System;
using AuthTemplate.Models;
namespace AuthTemplate.Services
{
	public interface IRegistrationService
	{
        Task<AuthResponse> Register(RegistrationRequest registrationRequest);
    }
}

