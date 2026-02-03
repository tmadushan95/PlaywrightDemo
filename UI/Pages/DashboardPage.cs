using Microsoft.Playwright;
using PlaywrightDemo.Enums;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.Mapping;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.Pages;

public sealed class DashboardPage(IPage _page, TestConfig _config) : IDashboardPage
{
    /// <summary>
    /// Navigates to the dashboard page and waits until the page has fully loaded.
    /// </summary>
    public async Task OpenDashboardPageAsync()
    {
        // Navigate to the dashboard page URL
        var route = PageUrlMapping.Routes[EnumPage.Dashboard];

        // Wait for the page to load completely
        await _page.WaitForURLAsync($"**{route}", new PageWaitForURLOptions { Timeout = _config.Playwright.TimeoutMs });
    }

    /// <summary>
    /// Asynchronously determines whether the dashboard page has finished loading by checking for the presence of a
    /// welcome message.
    /// </summary>
    public async Task<bool> IsDashboardPageLoadedAsync()=>
        await _page.Locator("text=Welcome back,").IsVisibleAsync();

}