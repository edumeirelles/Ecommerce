namespace DAL.ViewModels
{
    public class CategoryViewModel : EntityBaseViewModel
    {
        public string? Name { get; set; }
        public string? ImgPath { get; set; }
        public List<ProductViewModel>? Products { get; set; }

    }
}
