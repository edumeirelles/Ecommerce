namespace Ecommerce.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public int Stock { get; set; }
        public Dictionary<string, object>? Details { get; set; }
    }
}
