using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueboxPortal4.Startup))]
namespace BlueboxPortal4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
