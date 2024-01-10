using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Model;

namespace WebApp.Pages.Credit
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.Model.WebAppDbContext _context;

        public DeleteModel(WebApp.Data.Model.WebAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Logic Logic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Credits == null)
            {
                return NotFound();
            }

            var logic = await _context.Credits.FirstOrDefaultAsync(m => m.Id == id);

            if (logic == null)
            {
                return NotFound();
            }
            else
            {
                Logic = logic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Credits == null)
            {
                return NotFound();
            }
            var logic = await _context.Credits.FindAsync(id);

            if (logic != null)
            {
                Logic = logic;
                _context.Credits.Remove(Logic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
