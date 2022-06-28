
using System.ComponentModel.DataAnnotations.Schema;

namespace Orgs.Module.BusinessObjects
{
    public class CustomerContact : Contact
    {

        public CustomerContact()
        {

        }

        [ForeignKey("OrganizationId")]
        public virtual Customer Customer { get; set; }
    }
}
