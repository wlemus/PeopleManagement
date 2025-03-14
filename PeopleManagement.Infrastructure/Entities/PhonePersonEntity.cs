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
    [Table("PhonePerson")]
    public class PhonePersonEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = "Mobile"; // Mobile, Home, Work
        [Required]
        public bool IsPrimary { get; set; } = false;

        public PersonEntity Person { get; set; }  // Propiedad de navegación
    }
}
