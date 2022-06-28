

using DevExpress.Persistent.Base;
using System.Collections.Generic;

namespace Orgs.Module.BusinessObjects
{
    [NavigationItem("Data")]

    public class Customer : Organization
    {

        public Customer()
        {
            Contacts = new List<CustomerContact>();
        }

        public virtual List<CustomerContact> Contacts { get; set; }

    }
}
