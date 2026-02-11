using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaywrightDemo.UI.Components;
using PlaywrightDemo.UI.Components.Interfaces;
using PlaywrightDemo.UI.Flows;
using PlaywrightDemo.UI.Flows.Interfaces;
using PlaywrightDemo.UI.Pages.DashboardPage;
using PlaywrightDemo.UI.Pages.Interfaces;
using PlaywrightDemo.UI.Pages.LoginPage;
using PlaywrightDemo.UI.Pages.OperationalUnitsPage;

namespace PlaywrightDemo.UI
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            #region Register Components

            services.AddScoped<INavigationBar, NavigationBar>();

            #endregion

            #region Register Flows

            services.AddScoped<ILoginFlow, LoginFlow>();
            services.AddScoped<IDashboardFlow, DashboardFlow>();
            services.AddScoped<IOperationalUnitsFlow, OperationalUnitsFlow>();

            #endregion

            #region Register Pages

            services.AddScoped<ILoginPage, LoginPage>();
            services.AddScoped<IDashboardPage, DashboardPage>();
            services.AddScoped<IOperationalUnitsPage, OperationalUnitsPage>();

            #endregion

            return services;
        }
    }
}
