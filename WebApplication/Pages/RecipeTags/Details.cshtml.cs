using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApplication.Pages_RecipeTags
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public DetailsModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public RecipeTag? RecipeTag { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeTag = await _context.RecipeTags
                .Include(r => r.Recipe)
                .Include(r => r.Tag).FirstOrDefaultAsync(m => m.Id == id);

            if (RecipeTag == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
