using DAL.Models;
using DAL.ViewModels;
using Microsoft.AspNetCore.Http;

namespace DAL.Interfaces
{
    public interface IProductService : IBaseService<Product>, IDisposable
    {
        List<ProductViewModel>? GetProducts();
        ProductViewModel? GetProduct(Guid id);        
        Guid AddOrUpdateProduct(ProductViewModel productViewModel);
    }
    public interface IProductImageService : IBaseService<ProductImage>, IDisposable
    {
        List<ProductImageViewModel> GetProductImages(Guid productId);
        Task<string> SaveFile(IFormFile file, string fileName);
    }
}
