using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MLWD5.Domain.Abstractions;
using MLWD5.Persistense.Data;
using Persistense.Repository;

namespace Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            //services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IRepository<Singer>, EfRepository<Singer>>();
            services.AddTransient<IRepository<Song>, EfRepository<Song>>();
            services.AddScoped<AppDbContext>();
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
}
