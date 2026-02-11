using PlaywrightDemo.Enums;

namespace PlaywrightDemo.UI.Components.Interfaces
{
    public interface INavigationBar
    {
        // Performs a click action on the specified navigation menu item asynchronously.
        Task<bool> NavigateToAsync(EnumPage enumPage);
    }
}
