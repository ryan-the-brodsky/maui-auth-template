using Microsoft.Extensions.Logging;
using AuthTemplate.Views.Startup;
using AuthTemplate.Views.Dashboard;
using AuthTemplate.ViewModels.Dashboard;
using AuthTemplate.ViewModels.Startup;
using AuthTemplate.Services;

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
        // Services
        builder.Services.AddSingleton<ILoginService, LoginService>();
		builder.Services.AddSingleton<IRegistrationService, RegistrationService>();
        // Views
        builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<RegistrationPage>();
		builder.Services.AddSingleton<DashboardPage>();
		builder.Services.AddSingleton<LoadingPage>();
		// ViewModels
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<RegistrationPageViewModel>();
		builder.Services.AddSingleton<DashboardPageViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();



        return builder.Build();
    }
}

