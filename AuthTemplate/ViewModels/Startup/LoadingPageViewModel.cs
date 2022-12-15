using System;
using AuthTemplate.Views.Startup;
using AuthTemplate.Views.Dashboard;
using AuthTemplate.Models;
using AuthTemplate.Controls;
using Newtonsoft.Json;
namespace AuthTemplate.ViewModels.Startup
{
	public class LoadingPageViewModel : BaseViewModel
	{
		public LoadingPageViewModel()
		{
			CheckUserLoginDetails();
		}

		private async void CheckUserLoginDetails()
		{
			string userDetailsStr = Preferences.Get(nameof(App.UserDetails), "");

			if(string.IsNullOrWhiteSpace(userDetailsStr))
			{
				await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
			}
			else
			{
				var userInfo = JsonConvert.DeserializeObject<UserInfo>(userDetailsStr);
				App.UserDetails = userInfo;
				AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
				await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
			}
		}
	}
}

