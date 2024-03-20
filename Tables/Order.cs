using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class Order
    {
        [Key]
        public string? Order_ID { get; set; }
        public string? Customer_ID { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Delivery_Date { get; set; }
        public string? Status { get; set; }
    }
}
