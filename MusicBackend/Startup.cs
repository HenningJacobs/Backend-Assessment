using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicBackend.Startup))]
namespace MusicBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
