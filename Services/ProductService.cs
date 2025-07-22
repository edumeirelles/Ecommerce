using Ecommerce.Interfaces;
using Ecommerce.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public List<ProductViewModel> GetProducts() 
        {
            return this.GetList().Select(x=> new ProductViewModel()
            {
                Description = x.Description,
                ImagePath = x.ImagePath,
                Name = x.Name,
                Details = x.Details ?? new Dictionary<string, object>(),
                Price = x.Price,
                Stock = x.Stock,
                Type = x.Type,              

            }).ToList();
        }
    }
   
}
