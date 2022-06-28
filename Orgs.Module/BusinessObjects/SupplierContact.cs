using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Orgs.Module.BusinessObjects
{
    public class SupplierContact : Contact
    {

        public SupplierContact()
        {

        }
        [ForeignKey("OrganizationId")]
        public virtual Supplier Supplier { get; set; }
    }
}
