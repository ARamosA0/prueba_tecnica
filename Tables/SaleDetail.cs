using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class SaleDetail
    {
        [Key]
        public string? Detail_ID { get; set; }
        public string? Sale_ID { get; set; }
        public string? Product_ID { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
