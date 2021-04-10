using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public IndexModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Recipe>? Recipes { get;set; }
        public IList<Product>? Products { get;set; }
        
        public TimeSpan? Time { get; set; }
        
        public RecipeTag? RecipeTag { get; set; }
        
        public SelectList? TagId { get; set; }
        
        public SelectList? ProductId { get; set; }
        public int Servings { get; set; }
        
        public async Task OnGetAsync(TimeSpan time, int servings, String tid, String good, String bad="noargs")
        {
            Servings = servings;
            TagId = new SelectList(_context.Tags, "Id", "Name");
            ProductId = new SelectList(_context.Products, "Id", "Name");

            Recipes = await _context.Recipes
                .Include(d => d.Ingredients)
                .Include(d => d.RecipeTags)
                .ToListAsync();
            if(bad != "noargs")
            {
                            Products = await _context.Products
                                .Include(d => d.Ingredients)
                                .Include(d => d.Stocks)
                                .ToListAsync();
                            Recipes = Recipes.Where(r => r.PrepTime <= time).ToList();
                            
                            Recipes = Recipes.Where(r => r.Servings >= servings).ToList();
                            
                            Recipes = Recipes.Where(r => 
                                    r.RecipeTags!.Any(w => w.TagId.ToString() == tid)).ToList();
                            
                            Recipes = Recipes.Where(r => r.Ingredients!.Any(i => i.ProductId.ToString() == good)).ToList();
                            
                            Recipes = Recipes.Where(r => r.Ingredients!.All(i => i.ProductId.ToString() != bad)).ToList();
                            
                            Recipes = Recipes.Where(r=>r.Ingredients!.All(i=> 
                                i.Quantity <= Products.First(p => p.Id == i.ProductId)
                                    .Stocks!.First().Amount)).ToList();
                
                            Time = time;
            }
        }
        
        [BindProperty]
        public Ingredient? Ingredient { get; set; }
        [BindProperty]
        public Recipe? Recipe { get; set; }

        public async Task<IActionResult> OnPostAsync(TimeSpan timespan, int people, String tagid, String goodfood, String badfood)
        {

            return RedirectToPage("./Index", new {time = timespan,  servings = people, tid = tagid, good = goodfood, bad=badfood});
        }
    }
}