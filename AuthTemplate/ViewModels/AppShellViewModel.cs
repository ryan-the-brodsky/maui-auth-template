using AuthTemplate.Views.Startup;
namespace AuthTemplate.ViewModels
{
	public partial class AppShellViewModel : BaseViewModel
	{
		[ICommand]
		async void LogOut()
		{
            Shell.Current.FlyoutIsPresented = false;
            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                Preferences.Remove(nameof(App.UserDetails));
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

		}
	}
}

