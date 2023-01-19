using System;
using System.Text;
using AuthTemplate.Models;
using Newtonsoft.Json;

namespace AuthTemplate.Services
{
	public class AccountManagementService : IAccountManagementService
	{
		public async Task<bool> ResetPassword(ResetPasswordRequest resetPasswordRequest)
		{
#if DEBUG
            HttpsClientHandlerService handler = new HttpsClientHandlerService();
            HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
#else
			var client = new HttpClient();
#endif
            string requestStr = JsonConvert.SerializeObject(resetPasswordRequest);

            var response = await client.PostAsync("https://localhost:7043/api/accounts/reset-password", new StringContent(requestStr, Encoding.UTF8, "application/json"));
            var json = await response.Content.ReadAsStringAsync();

			return response.IsSuccessStatusCode;
		}
	}
}

