using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApplication.Pages_Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public IndexModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Ingredient>? Ingredient { get;set; }

        public async Task OnGetAsync()
        {
            Ingredient = await _context.Ingredients
                .Include(i => i.Product)
                .Include(i => i.Recipe).ToListAsync();
        }
    }
}
