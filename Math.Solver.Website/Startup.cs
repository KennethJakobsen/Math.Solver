using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Math.Solver.Website.Startup))]
namespace Math.Solver.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
