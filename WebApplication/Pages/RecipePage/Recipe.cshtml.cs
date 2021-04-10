using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using Microsoft.AspNetCore.Razor.Language;

namespace WebApplication.Pages_Recipes
{
    public class RecipePageModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public RecipePageModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public Recipe? Recipe { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public int Servings { get; set; }
        public IEnumerable<Tag>? Tags { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int servings)
        {
            if (id == null)
            {
                return NotFound();
            }

            Servings = servings;
            Recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.RecipeTags)
                .FirstOrDefaultAsync(m => m.Id == id);

            Products = await _context.Products
                .Include(r => r.Unit)
                .ToListAsync();
            
            Tags = await _context.Tags
                .ToListAsync();

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
