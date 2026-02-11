namespace PlaywrightDemo.UI.Flows.Interfaces
{
    public interface IOperationalUnitsFlow
    {
        // Navigates to the Operational Units page
        Task<bool> OpenOperationalUnitsPageAsync();

        // Displays the details of the selected Operational Unit
        Task<bool> ViewOperationalUnitAsync(string name);
    }
}
