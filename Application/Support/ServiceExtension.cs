using Application.Orders;
using Application.Products;
using Domain.Products.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Support
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServiceConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IOrderApplication, OrderApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IProductValidator, ProductValidator>();

            return services;
        }
    }
}
