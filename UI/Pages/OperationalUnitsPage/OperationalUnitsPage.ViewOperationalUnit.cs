using Microsoft.Playwright;

namespace PlaywrightDemo.UI.Pages.OperationalUnitsPage
{
    public sealed partial class OperationalUnitsPage
    {
        /// <summary>
        /// Displays the details of the selected Operational Unit 
        /// </summary>
        public async Task<bool> ViewOperationalUnitAsync(string name)
        {
            // Clicks the "View" button for the specified operational unit and waits for the details header to become visible.
            await _page
                .GetByRole(AriaRole.Row, new() { Name = name })
                .GetByRole(AriaRole.Button, new() { Name = "View" })
                .First
                .ClickAsync();

            // Wait until the details header appears on the page
            var operationalUnitHeader = _page.Locator($"text={name}");
            await operationalUnitHeader.WaitForAsync(new LocatorWaitForOptions
            {
                Timeout = _config.Playwright.TimeoutMs,
            });

            // Return true if the details header is visible, indicating that the details page has loaded successfully.
            return await operationalUnitHeader.IsVisibleAsync();
        }
    }
}
