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
    public class IndexModel : PageModel
    {
        private readonly WebAppDbContext _context;

        public IndexModel(WebAppDbContext context)
        {
            _context = context;
        }

        public IList<Logic> Logic { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Credits != null)
            {
                Logic = await _context.Credits.ToListAsync();
            }
        }
    }
}
