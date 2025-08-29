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
        [Display(Name = "Descrição Reduzida")]
        public string? SmallDescription { get; set; }
        [Display(Name = "Preço")]
        public double Price { get; set; }
        [Display(Name = "Estoque")]
        public int Stock { get; set; }
        [Display(Name = "Detalhes")]
        public List<DetailsViewModel>? Details { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid CategoryId { get; set; }
        public List<ProductImageViewModel> ProductImages { get; set; } = [];
    }

    public class DetailsViewModel
    {
        [Display(Name = "Título do detalhe")]
        public string? Key { get; set; }
        [Display(Name = "Descrição")]
        public string? Value { get; set; }
    }

    public class ProductImageViewModel : EntityBaseViewModel
    {
        public string? ImagePath { get; set; }
        public int? Order { get; set; }

    }
}
