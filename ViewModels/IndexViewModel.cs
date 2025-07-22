using Ecommerce.Interfaces;
using Ecommerce.Models;

namespace Ecommerce.ViewModels
{    
public class IndexViewModel
    {
        private readonly IProductService _service;
        public IndexViewModel(IProductService service)
        {
            _service = service;

            Products = _service.GetProducts() ?? [];
            Types = Products.Select(x => x.Type).Distinct().ToList() ?? [];
        }
        public List<ProductViewModel> Products { get; set; }
        public List<string> Types { get; set; }

    }
}
