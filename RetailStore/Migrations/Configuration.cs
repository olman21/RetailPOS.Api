namespace RetailStore.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RetailStore.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<RetailStore.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RetailStore.Infrastructure.ApplicationDbContext context)
        {
            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "olmanmora21@gmail.com",
                EmailConfirmed = true
            };

            manager.Create(user, "admin");
        }
    }
}
