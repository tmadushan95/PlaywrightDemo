namespace PlaywrightDemo.UI.Flows.Interfaces
{
    public interface IOperationalUnitsFlow
    {
        // Navigates to the Operational Units page
        Task OpenOperationalUnitsPageAsync();

        // Checks if the Operational Units page is loaded
        Task<bool> IsOperationalUnitsPageLoadedAsync();
    }
}
