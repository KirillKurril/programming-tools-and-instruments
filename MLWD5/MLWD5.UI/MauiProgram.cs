using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using MLWD5.Aplication;
using MLWD5.UI.Pages;
using MLWD5.UI.ViewModels;
using MLWD5.Persistense;
using MLWD5.Persistense.Data;

namespace MLWD5.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            string settingsStream = "MLWD5.UI.appsettings.json";
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            
            var connStr = builder.Configuration
                .GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
            connStr = String.Format(connStr, dataDirectory);

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

            
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services
                .AddApplication()
                .AddPersistence(options)
                .RegisterPages()
                .RegisterViewModels();

            DbInitializer
                .Initialize(builder.Services.BuildServiceProvider())
                .Wait();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<Singers>();
            services.AddTransient<SongsDetails>();
            return services;
        }
        static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<SingersViewModel>();
            services.AddTransient<SongsDetailsViewModel>();
            return services;
        }
    }
}
