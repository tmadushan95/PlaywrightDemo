using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.Core;
using PlaywrightDemo.UI.Flows;
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
            // Login to the application using Microsoft authentication
            await _loginFlow.LoginWithMicrosoftAsync();

            // Verify that login was successful
            var isLoginSuccessful = await _loginFlow.IsLoginSuccessfulAsync();
            Assert.True(isLoginSuccessful, "Login should be successful.");

            // Open the dashboard page when login is successful if not Uncomment this line
            // await _dashboardFlow.OpenDashboardAsync();

            // Verify that the dashboard page is loaded
            var isDashboardLoaded = await _dashboardFlow.VerifyDashboardLoadedAsync();
            Assert.True(isDashboardLoaded, "Dashboard did not load successfully.");

            // Navigate to the Operational Units page
            await _operationalUnitsFlow.OpenOperationalUnitsPageAsync();

            // Verify that the Operational Units page is loaded
            var isOperationalUnitsPageLoaded = await _operationalUnitsFlow.IsOperationalUnitsPageLoadedAsync();
            Assert.True(isOperationalUnitsPageLoaded, "Operational Units page should be loaded.");

            // delay for observation
            await Task.Delay(60000);
        }
    }
}
