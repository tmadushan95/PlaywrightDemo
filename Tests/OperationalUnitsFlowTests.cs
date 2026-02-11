using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.Core;
using PlaywrightDemo.UI.Flows.Interfaces;

namespace PlaywrightDemo.Tests
{
    public class OperationalUnitsFlowTests(PlaywrightFixture fixture) : TestBase(fixture)
    {
        private ILoginFlow _loginFlow;
        private IDashboardFlow _dashboardFlow;
        private IOperationalUnitsFlow _operationalUnitsFlow;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            _loginFlow = Scope.Services.GetRequiredService<ILoginFlow>();
            _dashboardFlow = Scope.Services.GetRequiredService<IDashboardFlow>();
            _operationalUnitsFlow = Scope.Services.GetRequiredService<IOperationalUnitsFlow>();
        }

        [Fact]
        public async Task OperationalUnitsTest()
        {
            // Login to the application
            var isLoginSuccessful = await _loginFlow.LoginWithMicrosoftAsync();
            Assert.True(isLoginSuccessful, "Login should be successful.");

            // Verify that the dashboard page is loaded
            var isDashboardLoaded = await _dashboardFlow.OpenDashboardPageAsync();
            Assert.True(isDashboardLoaded, "Dashboard did not load successfully.");

            // Navigate to the Operational Units page
            // Assert that the Operational Units page is loaded successfully
            var isOperationalUnitsPageLoaded = await _operationalUnitsFlow.OpenOperationalUnitsPageAsync();
            Assert.True(isOperationalUnitsPageLoaded, "Operational Units page should be loaded.");

            // delay for observation
            await Task.Delay(5000);

            // View details of a specific operational unit (e.g., "Formosa")
            var isViewOperationalUnit = await _operationalUnitsFlow.ViewOperationalUnitAsync("Formosa");
            Assert.True(isViewOperationalUnit, "Operational Unit details should be displayed.");

            await Task.Delay(5000);

        }
    }
}
