using PlaywrightDemo.UI.Flows.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI.Flows
{
    public class OperationalUnitsFlow(IOperationalUnitsPage _operationalUnitsPage) : IOperationalUnitsFlow
    {
        /// <summary>
        /// Navigates asynchronously to the Operational Units page.
        /// </summary>
        public async Task<bool> OpenOperationalUnitsPageAsync() =>
          await _operationalUnitsPage.OpenAsync();

        public async Task<bool> ViewOperationalUnitAsync(string name) =>
            await _operationalUnitsPage.ViewOperationalUnitAsync(name);
    }
}
