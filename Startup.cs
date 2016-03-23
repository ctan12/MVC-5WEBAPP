using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fwtest3.Startup))]
namespace Fwtest3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
