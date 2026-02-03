using PlaywrightDemo.UI.Flows.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI.Flows
{
    public class OperationalUnitsFlow(IOperationalUnitsPage _operationalUnitsPage) : IOperationalUnitsFlow
    {
        /// <summary>
        /// Navigates asynchronously to the Operational Units page.
        /// </summary>
        public async Task OpenOperationalUnitsPageAsync() =>
          await _operationalUnitsPage.OpenOperationalUnitsAsync();

        /// <summary>
        /// Asynchronously determines whether the Operational Units page has finished loading.
        /// </summary>
        public async Task<bool> IsOperationalUnitsPageLoadedAsync() =>
            await _operationalUnitsPage.IsOperationalUnitsPageLoadedAsync();
    }
}
