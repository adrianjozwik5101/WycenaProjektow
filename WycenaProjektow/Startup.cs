using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WycenaProjektow.Startup))]
namespace WycenaProjektow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
