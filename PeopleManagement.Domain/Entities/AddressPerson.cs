

namespace PeopleManagement.Infrastructure.Entities
{
    public class AddressPerson {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Type { get; set; } = "Personal"; // Home, Work, Other
    }
}
