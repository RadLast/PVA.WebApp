using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Data.Model;

namespace WebApp.Pages.Credit
{
    public class CreateModel : PageModel
    {
        private readonly WebAppDbContext _context;

        public CreateModel(WebAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Logic Logic { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Credits == null || Logic == null)
            {
                return Page();
            }

            Logic.Created = DateTime.Now;

            _context.Credits.Add(Logic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
