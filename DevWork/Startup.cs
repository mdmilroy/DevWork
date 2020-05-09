using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DevWork.Startup))]

namespace DevWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            //CreateRole();
        }

        //private void CreateRole()
        //{
        //    ApplicationDbContext ctx = new ApplicationDbContext();
        //    RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
        //    UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

        //    if (!roleManager.RoleExists("employer"))
        //    {
        //        roleManager.Create(new IdentityRole("employer"));
        //    }
        //    if (!roleManager.RoleExists("freelancer"))
        //    {
        //        roleManager.Create(new IdentityRole("freelancer"));
        //    }
        //}
    }
}
