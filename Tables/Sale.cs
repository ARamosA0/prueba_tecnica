using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class Sale
    {
        [Key]
        public string? Sale_ID { get; set; }
        public string? Employee_ID { get; set; }
        public DateTime Sale_Date { get; set; }
        public decimal Total { get; set; }
        public string? Payment_Method { get; set; }
    }
}
