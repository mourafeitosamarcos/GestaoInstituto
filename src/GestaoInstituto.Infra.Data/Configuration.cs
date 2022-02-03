using GestaoInstituto.Domain.UoW;
using GestaoInstituto.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace GestaoInstituto.Infra.Data
{
    public static class Configuration
    {
        public static IServiceCollection AddInfraDataSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<GestaoContext>(options =>
                 options.UseMySql(connection)
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
