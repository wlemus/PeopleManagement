using PeopleManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Infrastructure.Entities {
    [Table("Person")]
    public class PersonEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdentityDocument { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required] 
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }

        // Contact information
        public virtual ICollection<PhonePersonEntity> Phones { get; set; } = new List<PhonePersonEntity>();
        public virtual ICollection<EmailPersonEntity> Emails { get; set; } = new List<EmailPersonEntity>();
        public virtual ICollection<AddressPersonEntity> Addresses { get; set; } = new List<AddressPersonEntity>();
    }

}
