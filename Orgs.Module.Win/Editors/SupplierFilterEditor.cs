using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Orgs.Module.BusinessObjects;
using Orgs.Module.Win.Functions;
using System;
using System.Linq;

namespace Orgs.Module.Win.Editors
{
    [PropertyEditor(typeof(SupplierFilter), true)]
    public partial class SupplierFilterEditor : WinPropertyEditor
    {
        public SupplierFilterEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }
        SupplierFilterControl control;
        protected override object CreateControlCore()
        {
            control = new SupplierFilterControl();
            control.ApplyFilter += Control_ApplyFilter;
            return control;
        }
        private void Control_ApplyFilter()
        {
            var holder = View.CurrentObject as SupplierFilterHolder;

            //var sql = "select "
            MyFunctions.RefreshAndWarnMismatchIfNeeded(holder, View);
        }
    }
}
