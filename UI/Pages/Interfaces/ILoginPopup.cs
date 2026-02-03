namespace PlaywrightDemo.UI.Pages.Interfaces
{
    public interface ILoginPopup
    {
        // Performs login using the provided email and password
        Task OpenLoginPopupAsync(string email, string password);
    }
}
