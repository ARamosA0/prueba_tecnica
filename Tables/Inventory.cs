using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class Inventory
    {
        [Key]
        public string? Inventory_ID { get; set; }
        public string? Product_ID { get; set; }
        public string? Supplier_ID { get; set; }
        public int Quantity { get; set; }
        public DateTime Entry_Date { get; set; }
    }
}
