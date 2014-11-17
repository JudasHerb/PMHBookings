using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PMHBooking.Startup))]
namespace PMHBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
