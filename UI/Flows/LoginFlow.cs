using PlaywrightDemo.Infrastructure.Config;
using PlaywrightDemo.UI.Flows.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI.Flows
{
    public sealed class LoginFlow(ILoginPage _login, IDashboardPage _dashboardPage, TestConfig _config) : ILoginFlow
    {
        /// <summary>
        /// Performs an asynchronous login to the application using Microsoft account credentials.
        /// </summary>
        public async Task LoginWithMicrosoftAsync()
        {
            // Navigate to login page
            await _login.GotoLoginPageAsync();

            // Click Microsoft login button
            var loginPopup = await _login.ClickLoginPopupAsync();

            // Perform Microsoft login
            await loginPopup.OpenLoginPopupAsync(
                email: _config.Admin.Email,
                password: _config.Admin.Password
            );

            // Wait for dashboard page to load
            await _dashboardPage.OpenDashboardPageAsync();
        }

        /// <summary>
        /// Asynchronously determines whether the most recent login attempt was successful.
        /// </summary>
        public async Task<bool> IsLoginSuccessfulAsync() =>
            await _login.IsLoggingSuccessAsync();
    }
}
