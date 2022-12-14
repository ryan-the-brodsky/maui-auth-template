using AuthTemplate.Views.Dashboard;
using AuthTemplate.Views.Startup;
using AuthTemplate.ViewModels;
namespace AuthTemplate;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		BindingContext = new AppShellViewModel();
		Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
	}
}

