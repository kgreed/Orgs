using DevExpress.Persistent.Base;
using System;
using System.Linq;

namespace Orgs.Module.BusinessObjects
{
    public class SupplierFilter : IFilter
    {
        public SupplierFilter()
        {
            Name = "";
        }

        [VisibleInDetailView(true)]
        public string Name { get; set; }


        public void Reset()
        {
            Name = "";
        }
    }
}
