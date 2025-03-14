using PeopleManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Domain
{
    public class Person
    {
           public int Id { get; set; }
            public string IdentityDocument { get; set; } = string.Empty;
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; }

        // Contact information
        public List<PhonePerson> Phones { get; set; } = new List<PhonePerson>();
        public List<EmailPerson> Emails { get; set; } = new List<EmailPerson>();
        public List<AddressPerson> Addresses { get; set; } = new List<AddressPerson>();
        
    }
}
