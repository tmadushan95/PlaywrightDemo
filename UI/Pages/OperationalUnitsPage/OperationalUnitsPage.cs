using Microsoft.Playwright;
using PlaywrightDemo.Enums;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.UI.Components.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;
namespace PlaywrightDemo.UI.Pages.OperationalUnitsPage;

public sealed partial class OperationalUnitsPage(IPage _page, INavigationBar _navigationBar,TestConfig _config) : IOperationalUnitsPage
{
    /// <summary>
    /// Navigates asynchronously to the Operational Units page in the application.
    /// </summary>
    public async Task<bool> OpenAsync() =>
        await _navigationBar.NavigateToAsync(EnumPage.OperationUnits);
}