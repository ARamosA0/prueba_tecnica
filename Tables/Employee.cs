using System.ComponentModel.DataAnnotations;

namespace Tables
{
    public class Employee
    {
        [Key]
        public string? Employee_ID { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime Hiring_Date { get; set; }
    }
}
