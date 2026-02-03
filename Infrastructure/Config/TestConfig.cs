using Microsoft.Extensions.Configuration;
using PlaywrightDemo.Infrastructure.Config.Models;

namespace PlaywrightDemo.Infrastructure.Config
{
    public sealed class TestConfig
    {
        public PlaywrightSettings Playwright { get; }
        public UserCredentials Admin { get; }

        public TestConfig(IConfiguration config)
        {
            // Load Playwright settings
            var baseUrl = config.GetValue<string>("Playwright:BaseUrl")
                ?? throw new InvalidOperationException("Missing configuration: Playwright:BaseUrl");
            var timeoutMs = ParseTimeout(config["Playwright:TimeoutMs"]);

            Playwright = new()
            {
                BaseUrl = baseUrl,
                TimeoutMs = timeoutMs
            };

            // Load Admin credentials
            var email = config["Users:Admin:Email"]
                ?? throw new InvalidOperationException("Missing configuration: Users:Admin:Email");
            var password = config["Users:Admin:Password"]
                ?? throw new InvalidOperationException("Missing configuration: Users:Admin:Password");

            Admin = new()
            {
                Email = email,
                Password = password
            };
        }

        private static int ParseTimeout(string? value)
        {
            if (!int.TryParse(value, out var result))
                throw new InvalidOperationException($"Invalid Playwright:TimeoutMs value: '{value}'");
            return result;
        }
    }
}
