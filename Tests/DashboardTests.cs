using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.Core;
using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.UI.Flows.Interfaces;

namespace PlaywrightDemo.Tests
{
    public class DashboardTests(PlaywrightFixture _fixture) : TestBase(_fixture)
    {
        private ILoginFlow _loginFlow;
        private IDashboardFlow _dashboardFlow;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _loginFlow = Scope.Services.GetRequiredService<ILoginFlow>();
            _dashboardFlow = Scope.Services.GetRequiredService<IDashboardFlow>();
        }

        [Fact]
        public async Task DashboardTest()
        {
            // Login to the application
            var isLoginSuccessful = await _loginFlow.LoginWithMicrosoftAsync();
            Assert.True(isLoginSuccessful, "Login should be successful.");

            // Verify that the dashboard page is loaded
            var isDashboardLoaded = await _dashboardFlow.OpenDashboardPageAsync();
            Assert.True(isDashboardLoaded, "Dashboard did not load successfully.");

            await Task.Delay(5000);
        }
    }

}
