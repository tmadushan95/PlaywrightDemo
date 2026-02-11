using Microsoft.Playwright;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI.Pages.LoginPage
{
    public sealed partial class LoginPage(IPage _page, TestConfig _config) : ILoginPage
    {
        /// <summary>
        /// Navigates asynchronously to the login page of the application.
        /// </summary>
        public async Task OpenAsync() =>
            await _page.GotoAsync($"{_config.Playwright.BaseUrl}/login");
    }
}