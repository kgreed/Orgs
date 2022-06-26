using System;
using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace Orgs.Module.BusinessObjects {
    // This code allows our Model Editor to get relevant EF Core metadata at design time.
    // For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
	public class OrgsContextInitializer : DbContextTypesInfoInitializerBase {
		protected override DbContext CreateDbContext() {
			var optionsBuilder = new DbContextOptionsBuilder<OrgsEFCoreDbContext>()
                .UseSqlServer(@";");
            return new OrgsEFCoreDbContext(optionsBuilder.Options);
		}
	}
	//This factory creates DbContext for design-time services. For example, it is required for database migration.
	public class OrgsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrgsEFCoreDbContext> {
		public OrgsEFCoreDbContext CreateDbContext(string[] args) {
			throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
			//var optionsBuilder = new DbContextOptionsBuilder<OrgsEFCoreDbContext>();
			//optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Orgs");
			//return new OrgsEFCoreDbContext(optionsBuilder.Options);
		}
	}
	
}
