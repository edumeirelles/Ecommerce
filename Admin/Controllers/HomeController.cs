using DAL.ViewModels;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductService productService, ISiteConfigService siteConfigService) : BaseController(categoryService, productService, siteConfigService)
    {
        private readonly ILogger<HomeController> _logger = logger;        

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
