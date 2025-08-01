using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Product : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(3000)]
        public string? FullDescription { get; set; }
        [StringLength(500)]
        public string? SmallDescription { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0,int.MaxValue)]
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
