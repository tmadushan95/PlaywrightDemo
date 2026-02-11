namespace PlaywrightDemo.UI.Pages.Interfaces
{
    public interface IOperationalUnitsPage
    {
        // Navigates to the Operational Units page
        Task<bool> OpenAsync();

        // Displays the details of the selected Operational Unit
        Task<bool> ViewOperationalUnitAsync(string name);
    }
}
