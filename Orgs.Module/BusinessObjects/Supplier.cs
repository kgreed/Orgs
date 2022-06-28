using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Linq;

namespace Orgs.Module.BusinessObjects
{
    [NavigationItem("Data")]

    public class Supplier : Organization
    {

        public Supplier()
        {
            OrganizationType = 2;

        }


    }
}
