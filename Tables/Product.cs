using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class Product
    {
        [Key]
        public string? Product_ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Category { get; set; }
    }
}
