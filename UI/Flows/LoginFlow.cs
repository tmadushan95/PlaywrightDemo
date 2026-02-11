using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.UI.Flows.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI.Flows
{
    public sealed class LoginFlow(ILoginPage _loginPage, TestConfig _config) : ILoginFlow
    {
        /// <summary>
        /// Performs an asynchronous login to the application using Microsoft account credentials.
        /// </summary>
        public async Task<bool> LoginWithMicrosoftAsync()
        {
            // Navigate to login page
            await _loginPage.OpenAsync();

            // Click Microsoft login button
            // The MicrosoftLogin method will handle the entire login process, including filling in the email and password,
            // and will return true if the login was successful (i.e., if the welcome message is visible).
            return await _loginPage.MicrosoftLogin(_config.Admin.Email, _config.Admin.Password);
        }
    }
}
