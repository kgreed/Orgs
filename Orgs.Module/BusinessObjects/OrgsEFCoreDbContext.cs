using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using Microsoft.EntityFrameworkCore;
using System;

namespace Orgs.Module.BusinessObjects
{
    [TypesInfoInitializer(typeof(OrgsContextInitializer))]
    public class OrgsEFCoreDbContext : DbContext
    {
        public OrgsEFCoreDbContext(DbContextOptions<OrgsEFCoreDbContext> options) : base(options)
        {
        }
        public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<ModelDifference> ModelDifferences { get; set; }
        public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
        public DbSet<PermissionPolicyRole> Roles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationUserLoginInfo> UserLoginInfos { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<SupplierContact> SupplierContacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserLoginInfo>(b =>
            {
                b.HasIndex(nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.LoginProviderName), nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.ProviderUserKey)).IsUnique();
            });

            modelBuilder.Entity<Organization>().ToTable("Organizations");
            modelBuilder.Entity<Organization>().HasDiscriminator(x => x.OrganizationType)
                .HasValue<Customer>(1)
                .HasValue<Supplier>(2)
                ;

            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<Contact>().HasDiscriminator(x => x.ContactType)
                .HasValue<CustomerContact>(1)
                .HasValue<SupplierContact>(2)
                ;
        }
    }
}
