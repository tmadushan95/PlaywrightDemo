using PlaywrightDemo.UI.Flows.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI.Flows
{
    public sealed class DashboardFlow(IDashboardPage _dashboardPage) : IDashboardFlow
    {
        /// <summary>
        /// Asynchronously opens the dashboard page.
        /// </summary>
        public async Task OpenDashboardAsync()
        {
            // Use the dashboard page to open the dashboard
            await _dashboardPage.OpenDashboardPageAsync();
        }

        /// <summary>
        /// Asynchronously verifies whether the dashboard page has finished loading.
        /// </summary>
        public async Task<bool> VerifyDashboardLoadedAsync()
        {
            // Use the dashboard page to check if it is loaded
            return await _dashboardPage.IsDashboardPageLoadedAsync();
        }
    }
}
