using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;

namespace Orgs.Module.BusinessObjects
{
    [NavigationItem("Data")]
    [Table("Party")]
    public class Customer : Organization {

        public Customer() { 
        
        
        }


    }
}
