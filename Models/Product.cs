namespace Ecommerce.Models
{
    public class Product : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }       
        public required string ImagePath { get; set; }
        public int Stock { get; set; }
        public Dictionary<string, object>? Details { get; set; }

        public virtual Category Category { get; set; }

    }

    
}
