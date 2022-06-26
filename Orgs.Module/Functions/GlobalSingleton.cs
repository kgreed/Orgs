using Orgs.Module.BusinessObjects;
using System;
using System.Linq;

namespace Orgs.Module.Functions
{
   
    public sealed class GlobalSingleton
    {
        private static readonly Lazy<GlobalSingleton>
            lazy = new(() => new GlobalSingleton());

        private CustomerFilter _customerFilter;

        public CustomerFilter CustomerFilter
        {
            get => _customerFilter ??= MakeNewCustomerFilter();
            set => _customerFilter = value;
        }

        private static CustomerFilter MakeNewCustomerFilter()
        {
            var f1 = new CustomerFilter();
            var f2 = f1.ReadFromFile() as CustomerFilter;
            return f2 ?? f1;
        }

        private GlobalSingleton()
        {

        }

        public static GlobalSingleton Instance => lazy.Value;



    }
}
