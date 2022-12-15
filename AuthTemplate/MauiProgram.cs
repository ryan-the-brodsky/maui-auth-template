using Microsoft.Extensions.Logging;
using AuthTemplate.Views.Startup;
using AuthTemplate.Views.Dashboard;
using AuthTemplate.ViewModels.Dashboard;
using AuthTemplate.ViewModels.Startup;

namespace AuthTemplate;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		// Views
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<DashboardPage>();
		builder.Services.AddSingleton<LoadingPage>();
		// ViewModels
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<DashboardPageViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
		return builder.Build();
	}
}

