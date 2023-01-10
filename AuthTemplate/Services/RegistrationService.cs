using System;
using AuthTemplate.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
namespace AuthTemplate.Services
{
	public class RegistrationService : IRegistrationService
	{
		public async Task<AuthResponse> Register(RegistrationRequest registrationRequest)
		{
		#if DEBUG
            HttpsClientHandlerService handler = new HttpsClientHandlerService();
            HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
		#else
			var client = new HttpClient();
		#endif
			string requestStr = JsonConvert.SerializeObject(registrationRequest);

			var response = await client.PostAsync("https://localhost:7043/api/accounts/registration", new StringContent(requestStr, Encoding.UTF8, "application/json"));
            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
			{
				return JsonConvert.DeserializeObject<AuthResponse>(json);
			}
			else
			{
                return new AuthResponse
                {
					IsAuthSuccessful = false,
					ErrorMessage = "Unsuccessful registration"
                };
            }

		}
	}
}

