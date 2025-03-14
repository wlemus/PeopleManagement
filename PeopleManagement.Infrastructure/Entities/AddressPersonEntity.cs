using PeopleManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Infrastructure.Entities
{
    [Table("AddressPerson")]
    public class AddressPersonEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = "Home"; // Home, Work, Other
        public PersonEntity Person { get; set; }  // Propiedad de navegación
    }
}
