using E_ticaret.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_ticaret.Identity
{
    public class IdentityInitializer: CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Roller

            // Admin role
            if(!context.Roles.Any(i=> i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name = "admin",
                    Description = "admin rolü"
                };
                manager.Create(role);
            }

            // User role
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name = "user",
                    Description = "user rolü"
                };
                manager.Create(role);
            }

            // Admin Bilgileri
            /*if (!context.Users.Any(i => i.Name == "burakermis"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name="Burak",Surname="Ermiş",UserName= "burakermis",Email="burakermis@gmail.com" };

                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }*/

            // User Bilgileri
            /*if (!context.Users.Any(i => i.Name == "hasanermis"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Hasan", Surname = "Ermiş",UserName="hasanermis" ,Email = "hasanermis@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }*/

            base.Seed(context);
        }
    }
}