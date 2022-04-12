using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaloriesCount.Startup))]
namespace CaloriesCount
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
