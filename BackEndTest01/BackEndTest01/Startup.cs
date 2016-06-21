using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackEndTest01.Startup))]
namespace BackEndTest01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
