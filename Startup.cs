using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectApp.Startup))]
namespace ProjectApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
