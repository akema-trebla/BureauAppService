using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BureauAppServiceService.Startup))]

namespace BureauAppServiceService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}