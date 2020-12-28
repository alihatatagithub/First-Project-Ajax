using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxApplication.Startup))]
namespace AjaxApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
