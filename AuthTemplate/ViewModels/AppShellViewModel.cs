using AuthTemplate.Views.Startup;
namespace AuthTemplate.ViewModels
{
	public partial class AppShellViewModel : BaseViewModel
	{
		[ICommand]
		async void LogOut()
		{
			await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
			Shell.Current.FlyoutIsPresented = false;
		}
	}
}

