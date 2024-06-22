﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Profile.Data;

namespace Profile.Pages.AP
{
    public class DeleteModel : PageModel
    {
        private readonly Profile.Data.ApplicationDbContext _context;

        public DeleteModel(Profile.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Application Application { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Applications == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FirstOrDefaultAsync(m => m.Id == id);

            if (application == null)
            {
                return NotFound();
            }
            else 
            {
                Application = application;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Applications == null)
            {
                return NotFound();
            }
            var application = await _context.Applications.FindAsync(id);

            if (application != null)
            {
                Application = application;
                _context.Applications.Remove(Application);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
