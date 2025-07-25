using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class ProductViewModel : EntityBase
    {       
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }        
        public string? ImagePath { get; set; }
        public int Stock { get; set; }
        public Dictionary<string, object>? Details { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid CategoryId { get; set; }
        public List<ProductImageViewModel> ProductImages { get; set; } = [];

    }

    public class ProductImageViewModel : EntityBase
    {
        public required string ImagePath { get; set; }
        
    }
}
