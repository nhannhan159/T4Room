using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoomM.WebApp.Startup))]
namespace RoomM.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
