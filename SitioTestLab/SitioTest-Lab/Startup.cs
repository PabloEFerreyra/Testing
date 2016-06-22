using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SitioTest_Lab.Startup))]
namespace SitioTest_Lab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
