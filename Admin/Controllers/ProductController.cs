using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class ProductController(ICategoryService categoryService, IProductService productService, ISiteConfigService siteConfigService) : BaseController(categoryService, productService, siteConfigService)
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product()
        {            
            return View(_productService.GetProducts());
        }
    }
}
