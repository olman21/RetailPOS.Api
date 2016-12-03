using EntityFramework.Filters;
using RetailStore.DataAccess.EntityConfigurations;
using RetailStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.DataAccess
{
    public class RetailContext : DbContext
    {
        public RetailContext()
            : base("name=RetailContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<ContactType> ContactTypes { get; set; }

        public virtual DbSet<ContactMethodType> ContactMethodTypes { get; set; }

        public virtual DbSet<ContactMethodValue> ContactMethodValues { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetais { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = DateTime.UtcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Property("CreatedByID").IsModified = false;
                        entry.Property("CreatedDate").IsModified = false;
                        entity.ModifiedDate = DateTime.UtcNow;

                        if (entity.IsDeleted)
                            entity.DeletedDate = DateTime.UtcNow;
                    }
                }

            }
            return base.SaveChanges();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new MeasureUnitConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new ContactTypeConfiguration());
            modelBuilder.Configurations.Add(new ContactMethodTypeConfiguration());
            modelBuilder.Configurations.Add(new ContactMethodValueConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new OrderTypeConfiguration());
            modelBuilder.Configurations.Add(new PaymentMethodConfiguration());

            DbInterception.Add(new FilterInterceptor());

            var softDeleteFilter = FilterConvention.Create<BaseEntity>("SoftDelete",e => e.IsDeleted == false);
            modelBuilder.Conventions.Add(softDeleteFilter);
        }
    }
}
