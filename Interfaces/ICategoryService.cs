using Ecommerce.ViewModels;

namespace Ecommerce.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetCategories();
    }
}
