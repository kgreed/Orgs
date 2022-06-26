using System;
using System.Linq;

namespace Orgs.Module.BusinessObjects
{
    public interface IFilter
    {
        public void Reset();
        //CriteriaOperator GetCriteria();
        public IFilter ReadFromFile();
        public void SaveToFile();


    }
}
