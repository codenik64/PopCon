using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PopsConfectionary14.Models;

[assembly: OwinStartupAttribute(typeof(PopsConfectionary14.Startup))]
namespace PopsConfectionary14
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }
       
        
    }
}
