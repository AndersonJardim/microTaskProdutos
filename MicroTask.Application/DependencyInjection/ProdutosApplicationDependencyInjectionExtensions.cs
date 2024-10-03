using Microsoft.Extensions.DependencyInjection;
using MicroTask.Application.Service;
using MicroTask.Domain.Interfaces;

namespace MicroTask.Application.DependencyInjection
{
    public static class ProdutosApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection service)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));

            service.AddTransient<IProdutosService, ProdutosService>();

            return service;
        }
    }
}