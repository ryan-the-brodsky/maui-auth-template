using AuthTemplate.Handlers;
using Microsoft.Maui.Platform;
using AuthTemplate.Models;

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
}

