using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CharityProjectUI.Startup))]
namespace CharityProjectUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
