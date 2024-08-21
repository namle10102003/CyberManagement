using CyberManager.Application.Common.Interfaces.Services;
using CyberManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        public static IHostBuilder CreateHostBuilder()
        {
            return  Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) => {
                            //Add service
                            services.AddScoped<IGreeting, Greeting>();
                            services.AddTransient<Form1>();
                        });
        }
    }
}