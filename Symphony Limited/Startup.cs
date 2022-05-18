using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Symphony_Limited.Models;
using System;

[assembly: OwinStartupAttribute(typeof(Symphony_Limited.Startup))]
namespace Symphony_Limited
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }

        public void CreateDefaultRolesAndUsers()
        {
            var roleManager= new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user= new ApplicationUser();
                user.Email = "Viet@gmail.com";
                user.PasswordHash = "Viet1996.";

                var Check = userManager.Create(user, "Viet");
                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }
                else
                {
                    var e = new Exception("Could not add default user");
                    var enumerator = Check.Errors.GetEnumerator();
                    foreach (var error in Check.Errors)
                    {
                        e.Data.Add(enumerator.Current, error);
                    }
                    throw e;
                }
            }
        }
    }
}
