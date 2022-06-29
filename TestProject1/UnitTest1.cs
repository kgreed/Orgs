using Orgs.Module.BusinessObjects;
using Orgs.Module.Functions;
using System.Configuration;
 
 
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void T01_AddCustomerContact()
        {
            // var configfile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //var path = configfile.FilePath;

            // var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            var connectionString = "Integrated Security=SSPI;MultipleActiveResultSets=True;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Orgs";
 

            var db = DataHelpers.MakeDbContext(connectionString);
            var cust = new Customer
            {
                Name = Guid.NewGuid().ToString()
            };
            var contact = new CustomerContact
            {
                Customer = cust,
                FirstName = "Sally"
            };
            cust.Contacts.Add(contact);
            db.Customers.Add(cust);
            db.SaveChanges();


        }
    }
}