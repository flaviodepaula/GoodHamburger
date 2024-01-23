using Infra.Repository.Interfaces;
using Infra.Repository.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Repository.Support
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositoryServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
