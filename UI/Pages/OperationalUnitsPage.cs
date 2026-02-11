using Microsoft.Playwright;
using PlaywrightDemo.Enums;
using PlaywrightDemo.UI.Components.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;
namespace PlaywrightDemo.Pages;

public sealed class OperationalUnitsPage(IPage _page, INavigationBar _navigationBar) : IOperationalUnitsPage
{
    /// <summary>
    /// Navigates asynchronously to the Operational Units page in the application.
    /// </summary>
    public async Task OpenOperationalUnitsAsync() =>
        await _navigationBar.NavigateToAsync(EnumPage.OperationUnits);


    /// <summary>
    /// Asynchronously determines whether the Operational Units page is currently loaded and visible.
    /// </summary>
    public async Task<bool> IsOperationalUnitsPageLoadedAsync() =>
        await _page.Locator("text=View all scopes in a hierarchical tree structure. Expand or collapse nodes to navigate the hierarchy.").IsVisibleAsync();

    /// <summary>
    /// Displays the details of the selected Operational Unit 
    /// </summary>
    public async Task ViewOperationalUnitAsync(string name) =>
        await _page
            .GetByRole(AriaRole.Row, new() { Name = name })
            .GetByRole(AriaRole.Button, new() { Name = "View" })
            .ClickAsync();

    /// <summary>
    /// Asynchronously determines whether the details header for the specified operational unit is visible on the page.
    /// </summary>
    public async Task<bool> IsOperationalUnitDetailsVisibleAsync(string name) =>
        await _page.Locator($"text=Operational Unit Details - {name}").IsVisibleAsync();
}