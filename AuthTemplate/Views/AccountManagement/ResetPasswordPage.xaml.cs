using AuthTemplate.ViewModels.AccountManagement;

namespace AuthTemplate.Views.AccountManagement;

public partial class ResetPasswordPage : ContentPage
{
	public ResetPasswordPage(ResetPasswordPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
