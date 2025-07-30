using Ecommerce.Interfaces;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecommerce.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : BaseController
    {   
        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("~/")]
        [Route("/Home")]
        [Route("/Home/Index")]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Products = _productService.GetProducts(),
                Categories = _categoryService.GetCategories()
            };
            return View(viewModel);
        }

        [Route("/Category")]
        [HttpGet]        
        public IActionResult Category(Guid id)
        {
            var viewModel = _categoryService.GetCategory(id);
            
            if (viewModel == null)
            {
                return NotFound();
            }   

            return View(viewModel);
        }

        [Route("/Product")]
        [HttpGet]
        public IActionResult Product(Guid id)
        {
            var viewModel = _productService.GetProduct(id);

            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
