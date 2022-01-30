using Domain.UoW;
using Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data
{
    public static class Configuration
    {
        public static IServiceCollection AddInfraDataSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<GestaoContext>(options =>
                options.UseMySql(connection, ServerVersion.AutoDetect(connection))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
