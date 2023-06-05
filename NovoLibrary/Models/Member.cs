using System.Text.Json.Serialization;

namespace NovoLibrary.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
