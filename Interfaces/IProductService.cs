using Ecommerce.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.Interfaces
{
    public interface IProductService : IBaseService<Product>, IDisposable
    {
        List<ProductViewModel>? GetProducts();
        ProductViewModel? GetProduct(Guid id);
    }
}
