
using System.Collections.Generic;

namespace PeopleManagement.Domain {
    public class PhonePerson
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Type { get; set; } = "Mobile"; // Mobile, Home, Work
        public bool IsPrimary { get; set; } = false;
   
    }
}
