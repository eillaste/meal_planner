using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Ingredient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        // measured in Units
        public double? Quantity { get; set; }

        [MaxLength(128)] public string? Comment { get; set; }
    }
}