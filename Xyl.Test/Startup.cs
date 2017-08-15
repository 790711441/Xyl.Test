using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Xyl.Test.Startup))]
namespace Xyl.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
