using Ecommerce.Interfaces;
using Ecommerce.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public List<CategoryViewModel> GetCategories()
        {
           return this.GetList().Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImgPath = x.ImgPath
            }).OrderBy(x=> x.Name).ToList();
        }
    }
}
