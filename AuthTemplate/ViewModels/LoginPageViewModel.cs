using AuthTemplate.Views.Dashboard;

namespace AuthTemplate.ViewModels
{
	public partial class LoginPageViewModel : BaseViewModel
	{
		[ICommand]
		async void Login()
		{
			await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
		}
	}
}

