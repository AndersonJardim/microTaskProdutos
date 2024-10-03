using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroTask.Domain.Interfaces;

namespace MicroTask.Infra.Data.DependencyInjection
{
    public static class ProdutosRepositoryDependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraData(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));
            ArgumentNullException.ThrowIfNull(nameof(configuration));

            service.AddScoped<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("UrlBase")));

            service.AddTransient<IProdutosRepository, ProdutosRepository>();

            return service;
        }
    }
}