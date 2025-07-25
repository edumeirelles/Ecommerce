using Ecommerce.Interfaces;
using Ecommerce.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public List<ProductViewModel> GetProducts()
        {
            return this.GetList().Where(x=> x.IsActive).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Description = x.Description ?? string.Empty,
                ImagePath = x.ImagePath,
                Name = x.Name,
                Details = x.Details ?? new Dictionary<string, object>(),
                Price = x.Price,
                Stock = x.Stock,
                DateAdded = x.DateAdded

            }).ToList();
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var product = this.GetList().Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            if (product == null)
            {
                return new ProductViewModel();
            }
            return new ProductViewModel()
            {
                Id = product.Id,
                Description = product.Description ?? string.Empty,
                ImagePath = product.ImagePath,
                Name = product.Name,
                Details = product.Details ?? new Dictionary<string, object>(),
                Price = product.Price,
                Stock = product.Stock,
                DateAdded = product.DateAdded
            };
        }
    }
}
