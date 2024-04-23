using Microsoft.Extensions.Logging;
using MLWD5.Aplication;
using Persistense;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using MLWD5.UI.Pages;
using MLWD5.UI.ViewModels;

namespace MLWD5.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
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
                .AddPersistence()
                .RegisterPages()
                .RegisterViewModels();
                

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<Singers>();
            return services;
        }
        static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<SingersViewModel>();
            return services;
        }
    }
}
