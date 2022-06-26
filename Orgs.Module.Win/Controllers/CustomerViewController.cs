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
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerViewController : ViewController
    {
        SimpleAction actCustomerFilter;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CustomerViewController()
        {
            InitializeComponent();
            actCustomerFilter = new SimpleAction(this, "Customers", "View");
            actCustomerFilter.Execute += actCustomerFilter_Execute;
            
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void actCustomerFilter_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var filter = GlobalSingleton.Instance.CustomerFilter;
            var holder = new CustomerFilterHolder(filter);
            HolderFunctions.OpenFeature(holder, Application, e);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
