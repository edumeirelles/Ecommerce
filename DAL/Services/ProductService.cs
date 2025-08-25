using DAL.Models;
using DAL.Interfaces;
using DAL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class ProductService(IProductImageService productImageService) : BaseService<Product>, IProductService
    {   
        private readonly IProductImageService _productImageService = productImageService;
        public List<ProductViewModel> GetProducts()
        {
            return GetList().Where(x=> x.IsActive).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                FullDescription = x.FullDescription ?? string.Empty,                
                SmallDescription = x.SmallDescription ?? string.Empty,
                Title = x.Title,
                Details = x.Details ?? new Dictionary<string, object>(),
                Price = x.Price,
                Stock = x.Stock,
                DateAdded = x.DateAdded,
                CategoryId = x.CategoryId,
                ProductImages = _productImageService.GetProductImages(x.Id)

            }).ToList();
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var product = Get(id);
            if (product == null)
            {
                return new ProductViewModel();
            }
            return new ProductViewModel()
            {
                Id = product.Id,
                FullDescription = product.FullDescription ?? string.Empty,         
                SmallDescription = product.SmallDescription ?? string.Empty,
                Title = product.Title,
                Details = product.Details ?? [],
                Price = product.Price,
                Stock = product.Stock,
                DateAdded = product.DateAdded, 
                CategoryId = product.CategoryId,
                ProductImages = _productImageService.GetProductImages(product.Id)
            };
        }          
        
        public Guid AddProduct(ProductViewModel productViewModel)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Title = productViewModel.Title ?? string.Empty,
                FullDescription = productViewModel.FullDescription ?? string.Empty,
                SmallDescription = productViewModel.SmallDescription ?? string.Empty,
                Details = productViewModel.Details ?? [],
                Price = productViewModel.Price,
                Stock = productViewModel.Stock,
                DateAdded = DateTime.UtcNow,
                IsActive = true,
                CategoryId = productViewModel.CategoryId               
            };

            return Add(product);
        }
    }
    
    public class ProductImageService : BaseService<ProductImage>, IProductImageService
    {
        public List<ProductImageViewModel> GetProductImages(Guid productId)
        {
            var imagesList = GetList().Where(x => x.ProductId == productId).OrderBy(x=> x.Order).ToList();

            return imagesList.Count > 0 ? [.. imagesList.Select(x=> new ProductImageViewModel()
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                Order = x.Order
            })] : [new ProductImageViewModel() { ImagePath = "~/images/products/No_Image_Available.jpg" }];
        }

    }
}
