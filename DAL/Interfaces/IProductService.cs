using DAL.Models;
using DAL.ViewModels;

namespace DAL.Interfaces
{
    public interface IProductService : IBaseService<Product>, IDisposable
    {
        List<ProductViewModel>? GetProducts();
        ProductViewModel? GetProduct(Guid id);
        Guid AddProduct(ProductViewModel productViewModel);
    }
    public interface IProductImageService : IBaseService<ProductImage>, IDisposable
    {
        List<ProductImageViewModel> GetProductImages(Guid productId);        
    }
}
