using Application.Support;
using Infra.Repository.Support;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Logging;
using System.Diagnostics.CodeAnalysis;
using WebApi.Mappings;

namespace WebApi
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SolutionName = "GoodHamburger.V1";
        }

        public IConfiguration Configuration { get; }
        private string SolutionName { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });


            services.AddControllers();
            services.AddMvc();
            services.AddAutoMapper(typeof(WebApiMappings));

            services.AddApplicationServiceConfigurations()
                    .AddRepositoryServiceConfiguration();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }
             
            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();
             
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}