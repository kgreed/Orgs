using System.ComponentModel.DataAnnotations;

namespace Orgs.Module.BusinessObjects
{
     
    public abstract class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public int OrganizationType { get; set; }
    }
}