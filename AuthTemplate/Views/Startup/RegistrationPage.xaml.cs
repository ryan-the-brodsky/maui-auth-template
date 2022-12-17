using AuthTemplate.ViewModels.Startup;
namespace AuthTemplate.Views.Startup;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
