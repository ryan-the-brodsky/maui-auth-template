using System;
namespace AuthTemplate.Models
{
	public class AuthResponse
	{
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

