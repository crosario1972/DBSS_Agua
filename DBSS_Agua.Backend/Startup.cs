using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBSS_Agua.Backend.Startup))]
namespace DBSS_Agua.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
