using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.Pages;
using PlaywrightDemo.UI.Components;
using PlaywrightDemo.UI.Components.Interfaces;
using PlaywrightDemo.UI.Flows;
using PlaywrightDemo.UI.Flows.Interfaces;
using PlaywrightDemo.UI.Pages.Interfaces;

namespace PlaywrightDemo.UI
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            #region Register Flows

            services.AddScoped<ILoginFlow, LoginFlow>();
            services.AddScoped<IDashboardFlow, DashboardFlow>();
            services.AddScoped<IOperationalUnitsFlow, OperationalUnitsFlow>();

            #endregion

            #region Register Pages

            services.AddScoped<ILoginPopup, MicrosoftLoginPopup>();
            services.AddScoped<ILoginPage, LoginPage>();
            services.AddScoped<IDashboardPage, DashboardPage>();
            services.AddScoped<INavigationBar, NavigationBar>();
            services.AddScoped<IOperationalUnitsPage, OperationalUnitsPage>();

            #endregion

            return services;
        }
    }
}
