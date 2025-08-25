namespace DAL.ViewModels
{
    public class CategoryViewModel : EntityBaseViewModel
    {
        public string? Title { get; set; }
        public string? ImgPath { get; set; }
        public List<ProductViewModel>? Products { get; set; }

    }
}
