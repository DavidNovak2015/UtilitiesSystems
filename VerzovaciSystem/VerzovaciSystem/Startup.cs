using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VerzovaciSystem.Startup))]
namespace VerzovaciSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
