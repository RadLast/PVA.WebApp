using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Model;

namespace WebApp.Pages.Credit
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Data.Model.WebAppDbContext _context;

        public EditModel(WebApp.Data.Model.WebAppDbContext context)
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
            Logic = logic;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Logic.Created = DateTime.Now;

            _context.Attach(Logic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogicExists(Logic.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LogicExists(int id)
        {
            return (_context.Credits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
