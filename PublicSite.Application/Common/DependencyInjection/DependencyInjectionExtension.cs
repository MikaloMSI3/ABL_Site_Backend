using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PublicSite.Application.Common.Behavior;
using PublicSite.Application.Features.Actualities.Command.Create;
using PublicSite.Application.Interfaces;
using PublicSite.Application.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PublicSite.Application.Common.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddValidatorsFromAssemblyContaining<CreateActualityCommand>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //services.Scan(scan => scan.FromAssemblies(typeof(FileStorageService).Assembly)
            //.AddClasses()
            //.AsImplementedInterfaces()
            //.WithScopedLifetime());

            services.AddScoped<IFileStorageService, FileStorageService>();

            return services;
        }
    }
}
