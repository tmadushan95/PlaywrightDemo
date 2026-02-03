using Microsoft.Playwright;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.Pages;

public sealed class LoginPage(IPage _page, TestConfig _config) : ILoginPage
{
    /// <summary>
    /// Navigates asynchronously to the login page of the application.
    /// </summary>
    public async Task GotoLoginPageAsync() =>
        await _page.GotoAsync($"{_config.Playwright.BaseUrl}/login");

    /// <summary>
    /// Initiates the Microsoft sign-in process by clicking the corresponding button and returns a handle to the
    /// resulting login popup.
    /// </summary>
    public async Task<ILoginPopup> ClickLoginPopupAsync()
    {
        // Waits for the popup to open.
        var popupTask = _page.WaitForPopupAsync();

        // Clicks the "Sign in with Microsoft" button to trigger the popup.
        await _page.ClickAsync("text=Sign in with Microsoft");

        // Returns a new instance of MicrosoftLoginPopup
        return new MicrosoftLoginPopup(await popupTask, _config);
    }

    /// <summary>
    /// Asynchronously determines whether the logging operation was successful by checking for the presence of a welcome
    /// message on the page.
    /// </summary>
    public async Task<bool> IsLoggingSuccessAsync() =>
        await _page.Locator("text=Welcome back,").IsVisibleAsync();
}