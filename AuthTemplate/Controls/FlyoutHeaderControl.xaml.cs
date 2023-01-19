namespace AuthTemplate.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

		if(App.UserDetails != null)
		{
			lblUserName.Text = $"Hi, {App.UserDetails.FirstName}";
		}
	}
}
