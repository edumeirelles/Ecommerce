using DAL.Interfaces;
using DAL.ViewModels;
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

        public IActionResult ProductDetails(Guid id)
        {
            var viewModel = _productService.GetProduct(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductDetails", new { id = viewModel.Id });
            }
            if (!_productService.UpdateProduct(viewModel))
            {
                TempData["ErrorMessage"] = "Error updating product.";
                return View("ProductDetails", new { id = viewModel.Id });
            }
            TempData["SuccessMessage"] = $"Produto {viewModel.Title} - ID: {viewModel.Id} editado com sucesso";
            return RedirectToAction("ProductDetails", new {id = viewModel.Id});
        }
    }
}
