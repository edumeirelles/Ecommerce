namespace Ecommerce.Models
{
    public class Category : EntityBase
    {
        public required string Name { get; set; }
        public required string ImgPath { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
   
}
