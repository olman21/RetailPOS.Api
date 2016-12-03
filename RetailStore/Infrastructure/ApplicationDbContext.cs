using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace RetailStore.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("RetailContext", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        

    }
}