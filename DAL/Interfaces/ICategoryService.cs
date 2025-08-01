using DAL.Models;
using DAL.ViewModels;

namespace DAL.Interfaces
{
    public interface ICategoryService : IBaseService<Category>, IDisposable
    {
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategory(Guid id);
    }
}
