using Microsoft.Playwright;
using PlaywrightDemo.Enums;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.Mapping;
using PlaywrightDemo.UI.Components.Interfaces;

namespace PlaywrightDemo.UI.Components;

public class NavigationBar(IPage _page,TestConfig _config) : INavigationBar
{
    /// <summary>
    /// Navigates to the specified page by clicking the corresponding item in the navigation menu and waits for the page
    /// to load.
    /// </summary>
    public async Task NavigateToAsync(EnumPage enumPage)
    {
        // Get the route for the specified EnumPage item
        var route = PageUrlMapping.Routes[enumPage];

        // Locate the navigation bar and the specific link
        var nav = _page.Locator("nav");
        var link = nav.Locator($"a[href='{route}']");

        // Click the link and wait for navigation to complete
        await Task.WhenAll(
            _page.WaitForURLAsync($"**{route}", new PageWaitForURLOptions { Timeout = _config.Playwright.TimeoutMs }),
            link.ClickAsync()
        );
    }
}