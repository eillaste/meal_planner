using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Stock
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; } = default!;

        [MaxLength(64)]
        public string Location { get; set; } = default!;
        
        // measured in Units
        public int? Amount { get; set; } = default!;
        
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}