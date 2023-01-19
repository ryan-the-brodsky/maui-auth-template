using System;
namespace AuthTemplate.Models
{
	public class UserInfo
	{
		public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Token { get; set; }
    }
}

