using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueBadge.WebMVC.Startup))]
namespace BlueBadge.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
