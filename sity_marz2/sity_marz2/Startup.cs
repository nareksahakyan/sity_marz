using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sity_marz2.Startup))]
namespace sity_marz2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
