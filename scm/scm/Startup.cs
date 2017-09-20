using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(scm.Startup))]
namespace scm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
