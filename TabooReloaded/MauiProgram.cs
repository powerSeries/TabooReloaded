using Microsoft.Extensions.Logging;
using TabooReloaded.Shared.Services;
using TabooReloaded.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace TabooReloaded;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        var temp = typeof(App).GetTypeInfo().Assembly;

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile(new EmbeddedFileProvider(temp),"appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        builder.Configuration.AddConfiguration(config);

        builder.UseMauiApp<App>()
               .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

        // Add device-specific services used by the TabooReloaded.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();
        builder.Services.AddSingleton<IDatabaseService, MongoService>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
