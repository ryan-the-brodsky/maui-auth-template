using System.Text;
using AuthTemplate.Models;
using Newtonsoft.Json;
using System.Net;
namespace AuthTemplate.Services
{
	public class LoginService : ILoginService
	{
		public async Task<AuthResponse> Authenticate(LoginRequest loginRequest)
		{
			#if DEBUG
						HttpsClientHandlerService handler = new HttpsClientHandlerService();
						HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
			#else
						var client = new HttpClient();
			#endif
			{
				string loginStr = JsonConvert.SerializeObject(loginRequest);
				var response = await client.PostAsync("https://localhost:7043/api/accounts/Login", new StringContent(loginStr, Encoding.UTF8, "application/json"));
                var json = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
				{
					return JsonConvert.DeserializeObject<AuthResponse>(json);
				}
				else
				{
					return new AuthResponse()
					{
						IsAuthSuccessful = false,
						ErrorMessage = "Login Attempt Unsuccessful"
					};
				}
			}
		}
	}
}

