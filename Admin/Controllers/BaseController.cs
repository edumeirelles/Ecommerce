using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class BaseController(ICategoryService categoryService, IProductService productService, ISiteConfigService siteConfigService) : Controller
    {
        protected IProductService _productService = productService;
        protected ICategoryService _categoryService = categoryService;
        protected ISiteConfigService _siteConfigService = siteConfigService;
        
    }
}
