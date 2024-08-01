using Microsoft.Extensions.Logging;

namespace ShopCom;

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

        // Services
        builder.Services.AddSingleton<INavigationService, NavegationService>();

        // ViewModels
        builder.Services.AddTransient<HelpSopportViewModel>();
        builder.Services.AddTransient<HelpSupportDetailViewModel>();

        // Pages

        builder.Services.AddTransient<HelpSopportPage>();

        var dbContext = new ShopDbContext();
        dbContext.Database.EnsureCreated();
        dbContext.Dispose();

        // registro de rutas
        Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
        Routing.RegisterRoute(nameof(HelpSopportDetailPage), typeof(HelpSopportDetailPage));
        
#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
