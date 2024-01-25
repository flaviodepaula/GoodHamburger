using Infra.Repository.Context;
using Infra.Repository.Interfaces;
using Infra.Repository.Mappers;
using Infra.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Repository.Support
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositoryServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GoodHamburgerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddAutoMapper(typeof(RepositoryMappers));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
