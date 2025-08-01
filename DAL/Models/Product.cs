namespace DAL.Models
{
    public class Product : EntityBase
    {

        public string Name { get; set; }
        public string? FullDescription { get; set; }
        public string? SmallDescription { get; set; }
        public double Price { get; set; }       
        public int Stock { get; set; }
        public Dictionary<string, object>? Details { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; } = [];

      
    }

    public class ProductImage : EntityBase
    {
        public string ImagePath { get; set; }        
        public int? Order { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

}
