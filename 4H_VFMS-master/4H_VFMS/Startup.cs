using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4H_VFMS.Startup))]
namespace _4H_VFMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
