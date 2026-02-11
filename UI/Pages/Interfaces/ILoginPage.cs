namespace PlaywrightDemo.UI.Pages.Interfaces
{
    public interface ILoginPage
    {
        // Navigates to the login page
        Task OpenAsync();

        // Clicks on the login popup and returns the ILoginPopup interface
        Task<bool> MicrosoftLogin(string email, string password);
    }
}
