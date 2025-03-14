

namespace PeopleManagement.Infrastructure.Entities
{
    public class EmailPerson
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Type { get; set; } = "Personal"; // Personal, Work, Other
    }
}
