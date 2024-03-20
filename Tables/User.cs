using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class User
    {
        [Key]
        public string? ID_User { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Employee_ID { get; set; }
        public string? Role { get; set; }
    }
}
