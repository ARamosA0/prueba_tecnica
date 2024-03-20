using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class OrderDetail
    {
        [Key]
        public string? Detail_ID { get; set; }
        public string? Order_ID { get; set; }
        public string? Product_ID { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
