using AuthTemplate.ViewModels.Startup;

namespace AuthTemplate.Views.Startup;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
