using Ecommerce.Interfaces;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public List<ProductViewModel> GetProducts()
        {
            return GetList().Where(x=> x.IsActive).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Description = x.Description ?? string.Empty,                
                Name = x.Name,
                Details = x.Details ?? new Dictionary<string, object>(),
                Price = x.Price,
                Stock = x.Stock,
                DateAdded = x.DateAdded,
                CategoryId = x.Category.Id,
                ProductImages = x.ProductImages.Select(pi => new ProductImageViewModel()
                {
                    Id = pi.Id,
                    ImagePath = pi.ImagePath,
                    Order = pi.Order
                }).OrderBy(x=> x.Order).ThenBy(x => x.ImagePath).ToList()

            }).ToList();
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var product = GetList().Where(x => x.Id == id && x.IsActive).Include(x=> x.Category).Include(x=> x.ProductImages).FirstOrDefault();
            if (product == null)
            {
                return new ProductViewModel();
            }
            return new ProductViewModel()
            {
                Id = product.Id,
                Description = product.Description ?? string.Empty,                
                Name = product.Name,
                Details = product.Details ?? new Dictionary<string, object>(),
                Price = product.Price,
                Stock = product.Stock,
                DateAdded = product.DateAdded, 
                CategoryId = product.Category.Id,
                ProductImages = product.ProductImages.Select(pi => new ProductImageViewModel()
                {
                    Id = pi.Id,
                    ImagePath = pi.ImagePath,
                    Order = pi.Order
                }).OrderBy(x=> x.Order).ThenBy(x => x.ImagePath).ToList()
            };
        }
    }
}
