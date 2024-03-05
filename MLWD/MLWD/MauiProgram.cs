using Microsoft.Extensions.Logging;
using System.Net.Http;
using MLWD.Services;
using MLWD.Entities;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MLWD
{
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
            builder.Services.AddTransient<IDbService<MuseumHall, Exhibit>, MuseumDataBase>();
            builder.Services.AddSingleton<SQLiteDemo>();
            builder.Services.TryAddTransient<IRateService, RateService>();
            builder.Services.AddHttpClient<IRateService, RateService>(opt => opt.BaseAddress = new Uri("https://api.nbrb.by/exrates/rates/")); 
            builder.Services.AddSingleton<CurrencyConverter>();
            return builder.Build();

        }
    }
}
