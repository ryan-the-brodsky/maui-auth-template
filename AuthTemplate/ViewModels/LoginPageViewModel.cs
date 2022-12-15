using AuthTemplate.Views.Dashboard;
using AuthTemplate.Models;
using AuthTemplate.Controls;
using Newtonsoft.Json;

namespace AuthTemplate.ViewModels
{
	public partial class LoginPageViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string _email;

		[ObservableProperty]
		private string _password;

		[ICommand]
		async void Login()
		{
			if(!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
			{

				//api call

				var userDetails = new UserInfo()
				{
					Email = Email
				};

				

				if(Preferences.ContainsKey(nameof(App.UserDetails)))
				{
					Preferences.Remove(nameof(App.UserDetails));
				}

				string userDetailStr = JsonConvert.SerializeObject(userDetails);
				Preferences.Set(nameof(App.UserDetails), userDetailStr);
				App.UserDetails = userDetails;
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

            }
            await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
		}
	}
}

