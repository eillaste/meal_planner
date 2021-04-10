using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Recipe
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; } = default!;

        [MaxLength(4096)]
        public string Description { get; set; } = default!;
        
        [MaxLength(4096)]
        public string Instructions { get; set; } = default!;

        public int Servings { get; set; }

        public TimeSpan PrepTime { get; set; }

        //public int CategoryId { get; set; }
        //public Category? Category { get; set; }
        
        public ICollection<RecipeTag>? RecipeTags { get; set; }
        
        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}