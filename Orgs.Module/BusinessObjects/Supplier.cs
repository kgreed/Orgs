using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orgs.Module.BusinessObjects
{
    [NavigationItem("Data")]

    public class Supplier : Organization
    {

        public Supplier()
        {
            Contacts = new List<SupplierContact>();

        }

        public virtual List<SupplierContact> Contacts { get; set; }
    }
}
