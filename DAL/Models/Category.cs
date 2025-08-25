namespace DAL.Models
{
    public class Category : EntityBase
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
   
}
