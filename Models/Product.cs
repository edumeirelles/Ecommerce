namespace Ecommerce.Models
{
    public class Product : EntityBase
    {
        public required string Description { get; set; }
        public double Price { get; set; }
    }
}
