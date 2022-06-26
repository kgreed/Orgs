using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Orgs.Module.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Orgs.Module.BusinessObjects
{
    [DomainComponent]
    public class CustomerFilterHolder :IFilterHolder
    {
        public CustomerFilter Filter;

        public CustomerFilterHolder(CustomerFilter filter)
        {
            Filter = filter;
        }
 
        public List<Customer> Customers { get; set; }

        [NotMapped]
        [Browsable(false)]
        public IObjectSpace ObjectSpace { get; set; }

        public int ApplyFilter()
        {
            var sql = @"select Name,Id,Photo,Description,Customer_Email,FullName,Profile,WebSite , Address1ID,Address2ID,Discriminator 
                from Party where name like '%@p0%'";


            var db = DataHelpers.MakeDbContext();
            var parameters = new List<SqlParameter>
            {
                new SqlParameter
                {

                    DbType = System.Data.DbType.String,
                    ParameterName = "@p0",
                    Value = Filter.Name
                }
            };


            var results = db.Customers.FromSqlRaw(sql,parameters.ToArray());

            Customers = new List<Customer>();
            foreach (var r in results)
            {
                var o = ObjectSpace.GetObject(r);
                Customers.Add(o);
            }


            return Customers.Count();
        }

        public int ListCount()
        {
            return Customers.Count;
        }
    }
}
