using DevExpress.ExpressApp;

namespace Orgs.Module.BusinessObjects
{
    public interface IFilterHolder
    {
        int ApplyFilter();
        IObjectSpace ObjectSpace { get; set; }
        public int ListCount();

    }
}