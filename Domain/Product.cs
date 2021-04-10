using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; } = default!;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        
        public int UnitId { get; set; }
        public Unit? Unit { get; set; }
        
        public ICollection<Stock>? Stocks { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}