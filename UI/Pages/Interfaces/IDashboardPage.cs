namespace PlaywrightDemo.UI.Pages.Interfaces
{
    public interface IDashboardPage
    {
        // Navigates to the Dashboard page
        Task OpenDashboardPageAsync();

        // Checks if the Dashboard page is loaded
        Task<bool> IsDashboardPageLoadedAsync();
    }
}
