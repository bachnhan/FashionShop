using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FashionShopAdmin.Startup))]
namespace FashionShopAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
