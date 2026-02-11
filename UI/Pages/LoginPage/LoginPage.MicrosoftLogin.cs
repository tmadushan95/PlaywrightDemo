using Microsoft.Playwright;
using System.Threading;

namespace PlaywrightDemo.UI.Pages.LoginPage;

public sealed partial class LoginPage
{
    private IPage _popup;

    /// <summary>
    /// Initiates the Microsoft sign-in process by clicking the corresponding button and returns a handle to the
    /// resulting login popup.
    /// </summary>
    public async Task<bool> MicrosoftLogin(string email, string password)
    {
        // Waits for the popup to open.
        var popupTask = _page.WaitForPopupAsync();

        // Clicks the "Sign in with Microsoft" button to trigger the popup.
        await _page.ClickAsync("text=Sign in with Microsoft");

        // Waits for the popup to be available and assigns it to the _popup variable.
        _popup = await popupTask;

        // Returns a new instance of MicrosoftLoginPopup
        await OpenLoginPopupAsync(email, password);

        // Wait until the welcome message appears on the main page
        var welcomeLocator = _page.Locator("text=Welcome back,");
        await welcomeLocator.WaitForAsync(new LocatorWaitForOptions
        {
            Timeout = _config.Playwright.TimeoutMs,
        });

        // Return true if the welcome message is visible
        return await welcomeLocator.IsVisibleAsync();
    }

    /// <summary>
    /// Automates the login process by opening a popup and submitting the specified email and password asynchronously.
    /// </summary>
    private async Task OpenLoginPopupAsync(string email, string password)
    {
        // Email
        await _popup.WaitForSelectorAsync("input[name='loginfmt']", new() { Timeout = _config.Playwright.TimeoutMs });
        await _popup.FillAsync("input[name='loginfmt']", email);
        await _popup.ClickAsync("input[type='submit']");

        // Password
        await _popup.WaitForSelectorAsync("input[name='passwd']", new() { Timeout = _config.Playwright.TimeoutMs });
        await _popup.FillAsync("input[name='passwd']", password);
        await _popup.ClickAsync("input[type='submit']");

        // Handle Stay signed in prompt
        await HandleStaySignedInAsync();
    }

    /// <summary>
    /// Handles the 'Stay signed in?' prompt by detecting and clicking the confirmation button if it appears.
    /// </summary>
    private async Task HandleStaySignedInAsync()
    {
        try
        {
            // Stay signed in?
            var yesButton = await _popup.WaitForSelectorAsync(
                "input#idSIButton9",
                new PageWaitForSelectorOptions { Timeout = _config.Playwright.TimeoutMs }
            );

            // If the button is visible, click it
            if (yesButton != null && await yesButton.IsVisibleAsync())
            {
                await yesButton.ClickAsync();
            }
        }
        catch (TimeoutException)
        {
            throw new TimeoutException("Stay signed in prompt did not appear within the expected time.");
        }
    }
}