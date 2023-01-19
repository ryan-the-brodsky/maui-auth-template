using AuthTemplate.Handlers;
using Microsoft.Maui.Platform;
using AuthTemplate.Models;
using AuthTemplate.Views.Startup;
using AuthTemplate.Views.Dashboard;
using AuthTemplate.Views.AccountManagement;


namespace AuthTemplate;

public partial class App : Application
{
	public static UserInfo UserDetails;
	public App()
	{
		InitializeComponent();
		//borderless entry
		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
		{
			if (view is BorderlessEntry)
			{
#if __ANDROID__
				handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
			}
		});

		MainPage = new AppShell();
	}

    protected override async void OnAppLinkRequestReceived(Uri uri)
    {
        base.OnAppLinkRequestReceived(uri);

		string firstSegment = uri.Segments[0];

		if(firstSegment == "reset-password")
		{
            await Shell.Current.GoToAsync($"//{nameof(ResetPasswordPage)}");
        }
		else if(firstSegment == "google-auth-success")
		{
			await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
		}
    }
}

