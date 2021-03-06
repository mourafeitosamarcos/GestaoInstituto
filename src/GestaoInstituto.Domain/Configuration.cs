using FluentValidation;
using GestaoInstituto.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using static GestaoInstituto.Domain.Entities.User;

namespace GestaoInstituto.Domain
{
    public static class Configuration
    {
        public static IServiceCollection AddDomainSetup(this IServiceCollection services)
        {
            services.AddTransient<IValidator<User>, UserValidator>();

            return services;
        }
    }
}
