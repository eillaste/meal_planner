using Domain;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Ingredient> Ingredients { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Recipe> Recipes { get; set; } = default!;
        public DbSet<RecipeTag> RecipeTags { get; set; } = default!;
        public DbSet<Tag> Tags { get; set; } = default!;
        public DbSet<Unit> Units { get; set; } = default!;
        public DbSet<Stock> Stocks { get; set; } = default!;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}