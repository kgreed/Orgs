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
            get => _customerFilter ??= new CustomerFilter();
            set => _customerFilter = value;
        }



        private GlobalSingleton()
        {

        }

        public static GlobalSingleton Instance => lazy.Value;




        private SupplierFilter _supplierFilter;

        public SupplierFilter SupplierFilter
        {
            get => _supplierFilter ?? new SupplierFilter();
            set => _supplierFilter = value;
        }

    }
}
