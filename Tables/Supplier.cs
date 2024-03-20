using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class Supplier
    {
        [Key]
        public string? Supplier_ID { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
