using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class ProductController(ICategoryService categoryService, IProductService productService, ISiteConfigService siteConfigService) : BaseController(categoryService, productService, siteConfigService)
    {
        public IActionResult Index()
        {
            var viewModel = _productService.GetProducts();
            return View(viewModel);
        }
        public IActionResult Product(Guid id)
        {
            var viewModel = _productService.GetProduct(id);
            return View(viewModel);
        }
    }
}
