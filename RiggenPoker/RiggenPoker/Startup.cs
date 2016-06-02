using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RiggenPoker.Startup))]
namespace RiggenPoker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
