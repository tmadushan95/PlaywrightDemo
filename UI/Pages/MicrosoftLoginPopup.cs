using Microsoft.Playwright;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.Pages;

public sealed class MicrosoftLoginPopup(IPage _popup,TestConfig _config) : ILoginPopup
{
    /// <summary>
    /// Automates the login process by opening a popup and submitting the specified email and password asynchronously.
    /// </summary>
    public async Task OpenLoginPopupAsync(string email, string password)
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