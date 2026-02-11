using Microsoft.Playwright;
using PlaywrightDemo.Enums;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.Mapping;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI.Pages.DashboardPage
{
    public sealed class DashboardPage(IPage _page, TestConfig _config) : IDashboardPage
    {
        /// <summary>
        /// Navigates to the dashboard page and waits until the page has fully loaded.
        /// </summary>
        public async Task<bool> OpenAsync()
        {
            // Navigate to the dashboard page URL
            var route = PageUrlMapping.Routes[EnumPage.Dashboard];

            // Wait for the page to load completely
            await _page.WaitForURLAsync($"**{route}", new PageWaitForURLOptions { Timeout = _config.Playwright.TimeoutMs });

            return await _page.Locator("text=Welcome back,").IsVisibleAsync();
        }
    }
}