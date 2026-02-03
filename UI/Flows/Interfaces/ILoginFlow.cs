namespace PlaywrightDemo.UI.Flows.Interfaces
{
    public interface ILoginFlow
    {
        Task LoginWithMicrosoftAsync();
        Task<bool> IsLoginSuccessfulAsync();
    }
}
