using DBDatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Tables;

namespace Prueba_técnica.Pages
{
    public class ProductModel : PageModel
    {

        private readonly DatabaseContext _context;

        public ProductModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; private set; }

        [BindProperty]
        public Product producto { get; set; }
        public String option { get; set; }

        //Funcion get ordenado por el id
        public async Task<IActionResult> OnGetAsync()
        {
            Products = await _context.Products.OrderBy(p => p.Product_ID).ToListAsync();
            return Page();
        }

        [ValidateAntiForgeryToken]

        //Funcion post y edit de productos
        public async Task<IActionResult> OnPostAsync(string nameProduct, string desProduct, string presProduct, string catProduct)
        {
            Products = await _context.Products.OrderByDescending(p => p.Product_ID).ToListAsync();

            if (producto.Product_ID != null)
            {
                decimal numPrice = decimal.Parse(presProduct);
                var prod = new Product { Product_ID = producto.Product_ID, Name = nameProduct, Description = desProduct, Price = numPrice, Category = catProduct };
                Console.WriteLine(prod);
                _context.Products.Update(prod);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Product");
            }
            else
            {
                Products = await _context.Products.OrderBy(p => p.Product_ID).ToListAsync();
                int id = Products.Count + 1;
                string strId = (id).ToString();
                decimal numPrice = decimal.Parse(presProduct);

                _context.Products.Add(new Product { Product_ID = strId, Name = nameProduct, Description = desProduct, Price = numPrice, Category = catProduct });
                await _context.SaveChangesAsync();
                return RedirectToPage("./Product");
            }
        }

        // Llenamos los inputs del formulario con la data del producto seleccionado
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostEditAsync(string Product_id)
        {
                Products = await _context.Products.OrderBy(p => p.Product_ID).ToListAsync();
                option = "Editar";
                producto = await _context.Products.FindAsync(Product_id);
                if (producto != null)
                {
                    return Page();
                }
                else
                {
                    option = "";
                    Console.WriteLine("Producto null");
                return RedirectToPage("./Product");
            }
        }

        // Delete segun la seleccion
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {

            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Product");
            }
            else
            {
                Console.WriteLine("Error al eliminar");
                return Page();
            }

        }

        // Filtro de PRoductos segun el nombre
        public async Task<IActionResult> OnPostSearchAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToPage("./Product");
            }
            else
            {
                Products = _context.Products.Where(p => p.Name.Contains(searchTerm)).ToList();
                return Page();
            }
        }


    }
}
