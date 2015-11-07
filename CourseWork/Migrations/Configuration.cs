

namespace CourseWork.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using CourseWork.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CourseWork.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddRoleAndAdmin(CourseWork.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //create role "Student"
            ir = roleManager.Create(new IdentityRole("Student"));
            //create role "Tutor"
            ir = roleManager.Create(new IdentityRole("Tutor"));
            //create role "Admin" - only "Admin" can add user to role "Tutor"
            ir = roleManager.Create(new IdentityRole("Admin"));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "yaroslav.voznij@gmail.com"
            };
            ir = userManager.Create(user, "1Ter_miXOR");
            if(ir.Succeeded == false)
                return ir.Succeeded;
            
            ir = userManager.AddToRole(user.Id,"Admin");
            
            return ir.Succeeded;
        }

        protected override void Seed(CourseWork.Models.ApplicationDbContext context)
        {
            var res = AddRoleAndAdmin(context);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
