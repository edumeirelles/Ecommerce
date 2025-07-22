using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            
        }
        public List<ProductViewModel> Products { get; set; }
        public List<string> Types { get; set; }

    }
}
