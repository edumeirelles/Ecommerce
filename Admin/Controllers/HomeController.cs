using DAL.ViewModels;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IProductService productService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IProductService _productService = productService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProductViewModel viewModel)
        {
            viewModel.CategoryId = new Guid("098268d4-617a-413f-88f6-73521cded0f6");
            if (!ModelState.IsValid) 
            {
                return View();
            }
            _productService.AddProduct(viewModel);
            return View();
        }





        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
