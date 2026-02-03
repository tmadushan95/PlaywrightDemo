using PlaywrightDemo.Enums;

namespace PlaywrightDemo.UI.Pages.Interfaces
{
    public interface IOperationalUnitsPage
    {
        // Navigates to the Operational Units page
        Task OpenOperationalUnitsAsync();

        // Displays the details of the selected Operational Unit
        Task ViewOperationalUnitAsync(string name);

        // Checks if the Operational Units page is loaded
        Task<bool> IsOperationalUnitsPageLoadedAsync();

        // Checks if the details of the specified Operational Unit are visible
        Task<bool> IsOperationalUnitDetailsVisibleAsync(string name);
    }
}
