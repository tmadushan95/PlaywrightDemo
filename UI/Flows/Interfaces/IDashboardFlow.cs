using PlaywrightDemo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.UI.Flows.Interfaces
{
    public interface IDashboardFlow
    {
        Task OpenDashboardAsync();
        Task<bool> VerifyDashboardLoadedAsync();
    }

}
