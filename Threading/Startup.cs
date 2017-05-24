using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Threading.Startup))]
namespace Threading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
