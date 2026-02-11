using Allure.Net.Commons;
using Allure.Xunit.Attributes;
using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.Core;
using PlaywrightDemo.UI.Flows.Interfaces;

namespace PlaywrightDemo.Tests
{
    [AllureSuite("Operational Units Flow Tests")]
    [AllureFeature("Operational Units")]
    public class OperationalUnitsTests(PlaywrightFixture fixture) : TestBase(fixture)
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
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("View Operational Unit Details")]
        public async Task OperationalUnitsTest()
        {
            // Navigate to the login page and perform login
            Assert.True(await _loginFlow.LoginWithMicrosoftAsync(), "Login should be successful.");

            // Navigate to the dashboard page
            Assert.True(await _dashboardFlow.OpenDashboardPageAsync(), "Dashboard did not load successfully.");

            // Navigate to the Operational Units page
            Assert.True(await _operationalUnitsFlow.OpenOperationalUnitsPageAsync(), "Operational Units page should be loaded.");

            // delay for observation
            await Task.Delay(5000);

            // View details of a specific Operational Unit
            Assert.True(await _operationalUnitsFlow.ViewOperationalUnitAsync("Formosa"), "Operational Unit details should be displayed.");

            await Task.Delay(5000);

        }
    }
}
