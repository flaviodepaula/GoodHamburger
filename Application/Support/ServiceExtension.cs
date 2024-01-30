using Application.Interfaces;
using Application.Services;
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
