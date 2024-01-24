using Serilog;
using System.Diagnostics.CodeAnalysis;

namespace WebApi
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        private static IConfiguration Configuration
        {
            get
            {
                return new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
            }
        }

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            try
            {
                Log.Information("Iniciado Web Host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminado inesperadamente");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(async webhostBuilder =>
                {
                    webhostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                         _ = config.AddConfiguration(Configuration)
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath))
                        .UseStartup<Startup>();

                }).UseSerilog();

            return builder;
        }
    }
} 