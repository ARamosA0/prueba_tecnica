using DBDatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tables;

namespace Prueba_técnica.Pages
{
    public class loginModel : PageModel
    {
        private readonly DatabaseContext _context;

        // Tabla Usuario de la BD
        [BindProperty]
        public User User { get; set; }

        public loginModel(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Username == User.Username && u.Password == User.Password);

            if (userInDb == null)
            {
                // Si el usuario no existe o la contrase;a son incorrectos
                ModelState.AddModelError("", "Nombre de usuario o Contrase;a incorrectos.");
                Console.WriteLine("Nombre de usuario o Contrase;a incorrectos.");
                return Page();
            }

            // Si el inicio es exitoso va al index.
            return RedirectToPage("/Index", new { area = "", layout = "_layout_index" });
        }
    }
}
