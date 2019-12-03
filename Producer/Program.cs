using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Producer.Services;

namespace Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var rabbitMqClient = host.Services.GetService(typeof(IRabbitMqClient)) as IRabbitMqClient;

            rabbitMqClient.Setup();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
