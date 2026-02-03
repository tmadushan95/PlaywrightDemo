using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.UI;

namespace PlaywrightDemo.Core
{
    public static class ServiceFactory
    {
        public static IServiceProvider CreateRoot(PlaywrightFixture fixture)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton(fixture.Browser);
            services.AddSingleton(new TestConfig(config));

            // UI Services
            services.AddUIServices();

            services.AddScoped<IPage>(provider =>
            {
                var browser = provider.GetRequiredService<IBrowser>();
                var context = browser.NewContextAsync().GetAwaiter().GetResult();
                return context.NewPageAsync().GetAwaiter().GetResult();
            });

            return services.BuildServiceProvider();
        }
    }
}
