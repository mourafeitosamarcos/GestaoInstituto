using Domain.Entity;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entity.Usuario;

namespace Domain
{
    public static class Configuration
    {
        public static IServiceCollection AddDomainSetup(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Usuario>, UsuarioValidator>();

            return services;
        }
    }
}
