using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Profile.Data;

namespace Profile.Pages.AP
{
    public class IndexModel : PageModel
    {
        private readonly Profile.Data.ApplicationDbContext _context;

        public IndexModel(Profile.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Application> Application { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Applications != null)
            {
                Application = await _context.Applications.ToListAsync();
            }
        }
    }
}
