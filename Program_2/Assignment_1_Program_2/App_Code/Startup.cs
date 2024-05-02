using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_1_Project_2.Startup))]
namespace Assignment_1_Project_2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
