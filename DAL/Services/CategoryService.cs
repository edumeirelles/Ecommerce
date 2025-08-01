using DAL.Models;
using DAL.Interfaces;
using DAL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class CategoryService(IProductImageService productImageService) : BaseService<Category>, ICategoryService
    {
        private readonly IProductImageService _productImageService = productImageService;
        public List<CategoryViewModel> GetCategories()
        {            
            return GetList().Where(x=> x.IsActive).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImgPath = x.ImgPath,
                Products = x.Products!.Where(p=> p.IsActive).Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,                    
                    Price = p.Price,
                    CategoryId = p.Category.Id,
                    ProductImages = p.ProductImages.Count > 0 ? p.ProductImages.Select(pi => new ProductImageViewModel()
                    {
                        Id = pi.Id,
                        ImagePath = pi.ImagePath,
                        Order = pi.Order
                    }).OrderBy(x=> x.Order).ThenBy(x => x.ImagePath).ToList() : _productImageService.GetProductImages(p.Id)
                }).ToList()

            }).OrderBy(x => x.Name).ToList();
        }

        public CategoryViewModel GetCategory(Guid id)
        {
            var category = GetList().Where(x => x.Id == id && x.IsActive).Include(x => x.Products!).FirstOrDefault();
            if (category == null)
            {
                return new CategoryViewModel();
            }           

            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                ImgPath = category.ImgPath,
                Products = category.Products!.Where(p=> p.IsActive).Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,                    
                    Price = p.Price,
                    CategoryId = p.Category.Id,
                    ProductImages = p.ProductImages.Count > 0 ? p.ProductImages.Select(pi => new ProductImageViewModel()
                    {                       
                        ImagePath = pi.ImagePath,                        
                    }).OrderBy(x=> x.Order).ThenBy(x=> x.ImagePath).ToList() : _productImageService.GetProductImages(p.Id),                   
                }).ToList()
            };

        }
    }
}
