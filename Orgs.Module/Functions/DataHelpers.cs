using Microsoft.EntityFrameworkCore;
using Orgs.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orgs.Module.Functions
{

    public static  class DataHelpers
    {

        public static OrgsEFCoreDbContext MakeDbContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<OrgsEFCoreDbContext>()
                .UseSqlServer(connectionString);
            return new OrgsEFCoreDbContext(optionsBuilder.Options);
        }
    }
}
