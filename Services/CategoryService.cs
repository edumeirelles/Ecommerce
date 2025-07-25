using Ecommerce.Interfaces;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public List<CategoryViewModel> GetCategories()
        {
            return GetList().Where(x=> x.IsActive).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImgPath = x.ImgPath,
                Products = x.Products.Where(p=> p.IsActive).Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImagePath = p.ImagePath,
                    Price = p.Price

                }).ToList()

            }).OrderBy(x => x.Name).ToList();
        }

        public CategoryViewModel GetCategory(Guid id)
        {
            var category = GetList().Where(x => x.Id == id && x.IsActive).Include(x => x.Products).FirstOrDefault();
            if (category == null)
            {
                return new CategoryViewModel();
            }

            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                ImgPath = category.ImgPath,
                Products = category.Products.Where(p=> p.IsActive).Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImagePath = p.ImagePath,
                    Price = p.Price
                }).ToList()
            };

        }
    }
}
