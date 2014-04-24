using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Folferine.Website.Startup))]
namespace Folferine.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
