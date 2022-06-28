using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using Orgs.Module.BusinessObjects;
using Orgs.Module.Functions;
using System;
using System.Linq;

namespace Orgs.Module.Win.Controllers
{
    public class SupplierViewController : ViewController
    {
        //SimpleAction actSupplierFilter;
        public SupplierViewController() : base()
        {
            //actSupplierFilter = new SimpleAction(this, "Suppliers", "View");
            //actSupplierFilter.Execute += actSupplierFilter_Execute;


        }
        private void actSupplierFilter_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var filter = GlobalSingleton.Instance.SupplierFilter;
            var holder = new SupplierFilterHolder(filter);
            HolderFunctions.OpenFeature(holder, Application, e);
        }

    }
}
