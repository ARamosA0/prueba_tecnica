using System.ComponentModel.DataAnnotations;

namespace Reports
{
    public class VentasPorEmpleado
    {
        [Key]
        public string? Employee_ID { get; set; }
        public string? NombreEmpleado { get; set; }
        public int Mes { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal PorcentajeContribucion { get; set; }
        public int Anio { get; set; }
    }
}
