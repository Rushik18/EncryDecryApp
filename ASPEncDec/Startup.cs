using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPEncDec.Startup))]
namespace ASPEncDec
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
