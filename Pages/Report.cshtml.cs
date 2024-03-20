using DBDatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reports;
using Microsoft.AspNetCore.Authorization;
using Tables;
using Microsoft.Data.SqlClient;

namespace Prueba_técnica.Pages
{
    public class ReportModel : PageModel
    {

        private readonly DatabaseContext _context;

        public ReportModel(DatabaseContext context)
        {
            _context = context;
        }

        // Declaramos variables de apoyo
        public IList<VentasPorEmpleado> VentasPorEmpleado { get; set; }
        public IList<SalesReport> SalesReports { get; set; }
        public IList<int> SalesSelectAnio { get; set; }
        public IList<Employee> EmpSelectName { get; set; }

        // Diccionario para convercion de meses numericos a nombres
        public Dictionary<int, string> monthConvertion = new Dictionary<int, string>()
        {
            { 1, "Enero" },
            { 2, "Febrero" },
            { 3, "Marzo" },
            { 4, "Abril" },
            { 5, "Mayo" },
            { 6, "Junio" },
            { 7, "Julio" },
            { 8, "Agosto" },
            { 9, "Septiembre" },
            { 10, "Octubre" },
            { 11, "Noviembre" },
            { 12, "Diciembre" }
        };

        public async Task OnGetAsync()
        {
            // Filtracion para llenar el Select de anios
            var anioSel = await _context.Sales.Select(s=>s.Sale_Date.Year).ToArrayAsync();
            SalesSelectAnio = anioSel.Distinct().ToArray();

            EmpSelectName = await _context.Employees.ToArrayAsync();

            // Extraer la query de la URL
            if (Request.Query.TryGetValue("anio", out var anioValue))
            {
                string anio = anioValue.FirstOrDefault();
                var totalVentas = await _context.Sales.ToListAsync();
                decimal numTotalVentas = totalVentas.Sum(sale => sale.Total);
                int anioNum = int.Parse(anio);

                // Funcion con PROCEDURE
                VentasPorEmpleado = await _context.VentasPorEmpleados.FromSqlRaw("EXEC spVentasPorEmpleado @Anio={0}, @NumTotal={1}", anioNum, numTotalVentas).ToListAsync();

            }

            // Extraer la query de la URL
            // Es necesario pasar la fecha por la URL
            if (Request.Query.TryGetValue("start_date", out var start_dateValue)
                && Request.Query.TryGetValue("end_date", out var end_dateValue)
                && Request.Query.TryGetValue("employee_id", out var employee_idValue))
            {

                string employee_id = employee_idValue.FirstOrDefault();
                string start_date = start_dateValue.FirstOrDefault();
                string end_date = end_dateValue.FirstOrDefault();

                DateTime startDate = DateTime.Parse(start_date);
                DateTime endDate = DateTime.Parse(end_date);

                var salesPerMonth = await _context.Sales
                        .Where(p => p.Sale_Date == startDate || p.Sale_Date == endDate)
                        .ToListAsync();
                int cantVenta = salesPerMonth.Count();
                decimal ventaAlta = salesPerMonth.Sum(sale => sale.Total);

                // Funcion con PROCEDURE
                SalesReports = await _context.salesReports.FromSqlRaw("EXEC spSalesReports @StartDate ={0}, @EndDate ={1}, @EmployeeId ={2}, @cantVenta ={3}, @ventaAlta ={4}",
                    startDate, endDate, int.Parse(employee_id), cantVenta, ventaAlta).ToListAsync();
            }
        }
        
    }
}
