using MLWD5.Domain.Abstractions;
using MLWD5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MLWD5.Persistense.Data;
using Persistense.Repository;

namespace MLWD5.Persistense;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        //services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IUnitOfWork, FakeUnitOfWork>();
        /*services.AddTransient<IRepository<Singer>, EfRepository<Singer>>();*/
        services.AddTransient<IRepository<Singer>, FakeSingerRepository>();
        /*services.AddTransient<IRepository<Song>, EfRepository<Song>>();*/
        services.AddTransient<IRepository<Song>, FakeSongRepository>();
        services.AddScoped<AppDbContext>();
        services.AddDbContext<AppDbContext>(opts =>
        {
            var connectionString = "Data Source = Singers.db";
            opts.UseSqlite(connectionString);
        });
        return services;    
    }
    public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
    {
        services.AddPersistence()
        .AddSingleton<AppDbContext>(
       new AppDbContext((DbContextOptions<AppDbContext>)options));
        return services;
    }
}
