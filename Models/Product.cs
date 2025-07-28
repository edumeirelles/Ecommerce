namespace Ecommerce.Models
{
    public class Product : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }       
        public int Stock { get; set; }
        public Dictionary<string, object>? Details { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }

        public required virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; } = [];

    }

    public class ProductImage : EntityBase
    {
        public required string ImagePath { get; set; }
        public required Guid ProductId { get; set; }
        public int? Order { get; set; }
        public required virtual Product Product { get; set; }
    }

}
