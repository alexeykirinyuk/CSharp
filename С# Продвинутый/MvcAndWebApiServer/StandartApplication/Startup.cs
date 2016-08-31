using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StandartApplication.Startup))]
namespace StandartApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
