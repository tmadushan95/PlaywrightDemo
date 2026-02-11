using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.Core;
using PlaywrightDemo.UI.Flows.Interfaces;

namespace PlaywrightDemo.Tests
{
    public class LoginTests(PlaywrightFixture fixture) : TestBase(fixture)
    {
        private ILoginFlow _loginFlow;
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            _loginFlow = Scope.Services.GetRequiredService<ILoginFlow>();
        }

        [Fact]
        public async Task LoginTest()
        {
            // Login to the application using Microsoft authentication
            // Assert that the login process was successful
            var isLoginSuccessful = await _loginFlow.LoginWithMicrosoftAsync();
            Assert.True(isLoginSuccessful, "Login was not successful.");

            await Task.Delay(5000);
        }
    }
}
