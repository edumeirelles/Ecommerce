using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.ViewModels
{
    public class ProductViewModel : EntityBaseViewModel
    {
        [Display(Name = "Título")]
        public string? Title { get; set; }
        [Display(Name = "Descrição Completa")]
        public string? FullDescription { get; set; }
        public string? SmallDescription { get; set; }
        public double Price { get; set; } 
        public int Stock { get; set; }
        public Dictionary<string, object>? Details { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid CategoryId { get; set; }
        public List<ProductImageViewModel> ProductImages { get; set; } = [];

    }

    public class ProductImageViewModel : EntityBaseViewModel
    {
        public string? ImagePath { get; set; }
        public int? Order { get; set; }


    }
}
