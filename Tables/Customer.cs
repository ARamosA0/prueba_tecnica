using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Tables
{
    public class Customer
    {
        [Key]
        public string? Customer_ID { get; set; } 
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
