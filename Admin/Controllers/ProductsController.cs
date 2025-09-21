using DAL.Interfaces;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Admin.Controllers
{
    public class ProductsController(ICategoryService categoryService, IProductService productService, ISiteConfigService siteConfigService) : BaseController(categoryService, productService, siteConfigService)
    {
        public IActionResult Index()
        {
            var viewModel = _productService.GetProducts();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult ProductDetails(Guid id)
        {            
            var viewModel = _productService.GetProduct(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(ValueCountLimit = int.MaxValue)]
       
        public IActionResult ProductDetails(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductDetails", new { id = viewModel.Id });
            }
            var productId = _productService.AddOrUpdateProduct(viewModel);
            if (productId == Guid.Empty)
            {
                TempData["ErrorMessage"] = viewModel.Id == Guid.Empty ? "Error creating product." : "Error updating product.";
                return View("ProductDetails");
            }
            TempData["SuccessMessage"] = $"Produto {viewModel.Title} - ID: {productId} {(viewModel.Id == Guid.Empty ? "criado" : "editado")} com sucesso";
            return RedirectToAction("ProductDetails", new {id = productId});
        }
    }
}
