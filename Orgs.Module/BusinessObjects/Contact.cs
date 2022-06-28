using System.ComponentModel.DataAnnotations;

namespace Orgs.Module.BusinessObjects
{
    public abstract class Contact
    {

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int ContactType { get; set; }

        public int OrganizationId { get; set; }


         
    }


   
}