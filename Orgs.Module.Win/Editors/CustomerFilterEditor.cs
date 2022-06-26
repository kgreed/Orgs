using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Orgs.Module.BusinessObjects;
using Orgs.Module.Win.Functions;
using System;
using System.Linq;

namespace Orgs.Module.Win.Editors
{
    [PropertyEditor(typeof(CustomerFilter), true)]
    public partial class CustomerFilterEditor : WinPropertyEditor
    {
        public CustomerFilterEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }
        CustomerFilterControl control;
        protected override object CreateControlCore()
        {
            control = new CustomerFilterControl();
            control.ApplyFilter += Control_ApplyFilter;
            return control;
        }
        private void Control_ApplyFilter()
        {
            var holder = View.CurrentObject as CustomerFilterHolder;

            //var sql = "select "
            MyFunctions.RefreshAndWarnMismatchIfNeeded(holder, View);
        }
    }
}
