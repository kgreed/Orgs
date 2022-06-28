

using DevExpress.Persistent.Base;

namespace Orgs.Module.BusinessObjects
{
    [NavigationItem("Data")]
   
    public class Customer : Organization {

        public Customer() {

            OrganizationType = 1;
        }


    }
}
