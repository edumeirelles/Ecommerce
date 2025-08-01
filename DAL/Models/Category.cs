namespace DAL.Models
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
   
}
