namespace AuthTemplate.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

		if(App.UserDetails != null)
		{
			lblUserName.Text = App.UserDetails.Email;
			lblUserEmail.Text = App.UserDetails.Email;
		}
	}
}
