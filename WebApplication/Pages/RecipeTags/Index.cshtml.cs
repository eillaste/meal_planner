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
    public class IndexModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public IndexModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RecipeTag>? RecipeTag { get;set; }

        public async Task OnGetAsync()
        {
            RecipeTag = await _context.RecipeTags
                .Include(r => r.Recipe)
                .Include(r => r.Tag).ToListAsync();
        }
    }
}
