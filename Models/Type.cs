namespace Ecommerce.Models
{
    public class Type: EntityBase
    {       
        public required string Description { get; set; }
        public string? ImgPath { get; set; }        
        public bool IsActive { get; set; } 
        public int SortOrder { get; set; } 
        public virtual ICollection<Product> Products { get; set; }
    }
}
