using System.ComponentModel.DataAnnotations;

namespace Reports
{
    public class SalesReport
    {
        [Key]
        public string? Product_ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int Year { get; set; }
        public string? Month { get; set; }
        public int CantidadVentasMensual { get; set; }
        public decimal CantidadVentaMásAlta { get; set; }
        public string? NombreEmpleado { get; set; }
    }

}
