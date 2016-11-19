using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MooPlot.Startup))]
namespace MooPlot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
