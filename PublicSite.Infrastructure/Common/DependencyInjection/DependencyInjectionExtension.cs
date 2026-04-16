using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.NameTranslation;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using PublicSite.Infrastructure.Persistence.Repositories;
using PublicSite.Infrastructure.Persistence.Repositories.Command;
using PublicSite.Infrastructure.Persistence.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddPostgreSqlDB(this IServiceCollection services, IConfiguration configuration, string assembly)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DBContext>(options =>
                options.UseNpgsql(connectionString,
                    npgsqlOptions => npgsqlOptions.MigrationsAssembly(assembly)
                )
            );
            //services.Scan(scan => scan.FromAssemblies(typeof(UnitOfWork).Assembly)
            //.AddClasses()
            //.AsImplementedInterfaces()
            //.WithScopedLifetime());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IActualityRepositoryCommand, ActualityRepositoryCommand>();
            services.AddScoped<IActualityRepositoryQuery, ActualityRepositoryQuery>();

            return services;
        }
    }
}
