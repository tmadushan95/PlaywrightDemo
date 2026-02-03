namespace PlaywrightDemo.UI.Pages.Interfaces
{
    public interface ILoginPage
    {
        // Navigates to the login page
        Task GotoLoginPageAsync();

        // Clicks on the login popup and returns the ILoginPopup interface
        Task<ILoginPopup> ClickLoginPopupAsync();

        // Checks if the login was successful
        Task<bool> IsLoggingSuccessAsync();
    }
}
