using DAL.ViewModels;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductService productService, ISiteConfigService siteConfigService) : BaseController(categoryService, productService, siteConfigService)
    {
        private readonly ILogger<HomeController> _logger = logger;

        [Route("~/")]
        [Route("/Home")]
        [Route("/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
