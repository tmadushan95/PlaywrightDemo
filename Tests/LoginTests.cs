using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.Core;
using PlaywrightDemo.UI.Flows;
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
            // Perform login using Microsoft account
            await _loginFlow.LoginWithMicrosoftAsync();

            // Verify that login was successful
            var isLoginSuccessful = await _loginFlow.IsLoginSuccessfulAsync();
            Assert.True(isLoginSuccessful, "Login was not successful.");
        }
    }
}
