using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cuf.Web.Startup))]
namespace Cuf.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
