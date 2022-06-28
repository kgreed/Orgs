using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Orgs.Module.BusinessObjects;
using Orgs.Module.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orgs.Module.Win.Controllers
{
    public partial class CustomerViewController : ViewController
    {
        SimpleAction actCustomerFilter;
       
        public CustomerViewController()
        {
            InitializeComponent();
            actCustomerFilter = new SimpleAction(this, "Customers", "View");
            actCustomerFilter.Execute += actCustomerFilter_Execute;
            
            
        }
        private void actCustomerFilter_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var filter = GlobalSingleton.Instance.CustomerFilter;
            var holder = new CustomerFilterHolder(filter);
            HolderFunctions.OpenFeature(holder, Application, e);
        }
        
    }

    
}
