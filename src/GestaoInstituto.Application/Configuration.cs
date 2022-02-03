using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace GestaoInstituto.Application
{
    public static class Configuration
    {
        public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

