using AuthTemplate.ViewModels.Dashboard;

namespace AuthTemplate.Views.Dashboard;


public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
