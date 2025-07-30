namespace DAL.Models
{
    public class Category : EntityBase
    {
        public required string Name { get; set; }
        public required string ImgPath { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
   
}
