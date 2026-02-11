using PlaywrightDemo.UI.Flows.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI.Flows
{
    public sealed class DashboardFlow(IDashboardPage _dashboardPage) : IDashboardFlow
    {
        /// <summary>
        /// Asynchronously opens the dashboard page.
        /// </summary>
        public async Task<bool> OpenDashboardPageAsync()
        {
            // This method will return true if the dashboard page is successfully opened
            // and the expected element is visible, otherwise it will return false.
            return await _dashboardPage.OpenAsync();
        }
    }
}
