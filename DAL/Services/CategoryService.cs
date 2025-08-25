using DAL.Models;
using DAL.Interfaces;
using DAL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class CategoryService(IProductService productService) : BaseService<Category>, ICategoryService
    {

        private readonly IProductService _productService = productService;
        public List<CategoryViewModel> GetCategories()
        {
            return GetList().Where(x => x.IsActive).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                ImgPath = x.ImgPath,
                Products = _productService.GetProducts()!.Where(p => p.CategoryId == x.Id).ToList()

            }).OrderBy(x => x.Title).ToList();
        }

        public CategoryViewModel GetCategory(Guid id)
        {
            var category = Get(id);
            if (category == null)
            {
                return new CategoryViewModel();
            }

            return new CategoryViewModel()
            {
                Id = category.Id,
                Title = category.Title,
                ImgPath = category.ImgPath,
                Products = _productService.GetProducts().Where(p => p.CategoryId == category.Id).ToList()
            };

        }
    }
}
