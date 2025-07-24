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
            return this.GetList().Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImgPath = x.ImgPath,
                Products = x.Products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImagePath = p.ImagePath,
                    Price = p.Price

                }).OrderBy(y => y.Name).ToList()

            }).OrderBy(x => x.Name).ToList();
        }

        public CategoryViewModel GetCategory(Guid id)
        {
            var category = this.GetList().Where(x => x.Id == id).Include(x => x.Products).FirstOrDefault();

            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                ImgPath = category.ImgPath,
                Products = category.Products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImagePath = p.ImagePath,
                    Price = p.Price
                }).OrderBy(y => y.Name).ToList()
            };

        }
    }
}
