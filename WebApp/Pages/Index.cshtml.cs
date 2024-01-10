using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Model;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebAppDbContext _context;

        [BindProperty]
        public Logic Credit { get; set; } = new Logic();


        public IndexModel(WebAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Credit.Created = DateTime.Now;

            _context.Credits.Add(Credit);
            _context.SaveChanges();

            Credit = new Logic();

            ModelState.Clear();

            return Page();
        }

        public void OnGet()
        {

        }
    }
}