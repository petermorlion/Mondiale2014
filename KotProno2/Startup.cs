using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KotProno2.Startup))]
namespace KotProno2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureAutofac(app);
        }
    }
}
