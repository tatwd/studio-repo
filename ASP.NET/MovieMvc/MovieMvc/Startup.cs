using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieMvc.Startup))]
namespace MovieMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
