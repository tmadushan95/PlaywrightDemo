using Microsoft.Playwright;

namespace PlaywrightDemo.Core
{
    public sealed class PlaywrightFixture : IAsyncLifetime
    {
        public IPlaywright Playwright { get; private set; } = null!;
        public IBrowser Browser { get; private set; } = null!;

        public async Task InitializeAsync()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new()
            {
                Headless = false,
                SlowMo = 50,
            });
        }

        public async Task DisposeAsync()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}
