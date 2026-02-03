using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.Core;
using PlaywrightDemo.Enums;
using PlaywrightDemo.UI.Flows;
using PlaywrightDemo.UI.Flows.Interfaces;

namespace PlaywrightDemo.Tests
{
    public class DashboardTests : TestBase
    {
        private ILoginFlow _loginFlow;
        private IDashboardFlow _dashboardFlow;

        public DashboardTests(PlaywrightFixture fixture) : base(fixture) { }

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
            await _loginFlow.LoginWithMicrosoftAsync();

            // Verify that login was successful
            var isLoginSuccessful = await _loginFlow.IsLoginSuccessfulAsync();
            Assert.True(isLoginSuccessful, "Login should be successful.");

            // Open the dashboard page when login is successful if not Uncomment this line
            // await _dashboardFlow.OpenDashboardAsync();

            // Verify that the dashboard page is loaded
            var isDashboardLoaded = await _dashboardFlow.VerifyDashboardLoadedAsync();
            Assert.True(isDashboardLoaded, "Dashboard did not load successfully.");

            await Task.Delay(20000);
        }
    }

}
