using DAL.Interfaces;
using DAL.Models;
using DAL.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DAL.Services
{
    public class ProductService(IProductImageService productImageService, Lazy<ICategoryService> categoryService) : BaseService<Product>, IProductService
    {
        private readonly IProductImageService _productImageService = productImageService;
        private readonly Lazy<ICategoryService> _categoryService = categoryService;

        public List<ProductViewModel> GetProducts()
        {
            return [.. GetList().Where(x => x.IsActive).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                FullDescription = x.FullDescription ?? string.Empty,
                SmallDescription = x.SmallDescription ?? string.Empty,
                Title = x.Title,
                Details = x.Details?.Select(x => new DetailsViewModel()
                {
                    Key = x.Key ?? string.Empty,
                    Value = x.Value.ToString() ?? string.Empty
                }).ToList() ?? [],
                Price = x.Price,
                Stock = x.Stock,
                DateAdded = x.DateAdded,
                CategoryId = x.CategoryId,
                ProductImages = _productImageService.GetProductImages(x.Id)
            })];
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var product = Get(id);
            if (product == null)
            {
                return new ProductViewModel()
                {
                    Categorias = [.. _categoryService.Value.GetCategories().Select(x=> new SelectListItem()
                    {
                        Text = x.Title,
                        Value = x.Id.ToString()
                    })],
                };
            }
            return new ProductViewModel()
            {
                Id = product.Id,
                FullDescription = product.FullDescription ?? string.Empty,
                SmallDescription = product.SmallDescription ?? string.Empty,
                Title = product.Title,
                Details = product.Details?.Select(x => new DetailsViewModel()
                {
                    Key = x.Key ?? string.Empty,
                    Value = x.Value.ToString() ?? string.Empty
                }).ToList() ?? [],
                Price = product.Price,
                Stock = product.Stock,
                DateAdded = product.DateAdded,
                Categorias = [.. _categoryService.Value.GetCategories().Select(x=> new SelectListItem()
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                })],
                CategoryId = product.CategoryId,
                ProductImages = _productImageService.GetProductImages(product.Id)
            };
        }        

        public Guid AddOrUpdateProduct(ProductViewModel viewModel)
        {
            var productToAddOrUpdate = Get(viewModel.Id) ?? new Product();

            productToAddOrUpdate.Title = viewModel.Title ?? string.Empty;
            productToAddOrUpdate.FullDescription = viewModel.FullDescription;
            productToAddOrUpdate.SmallDescription = viewModel.SmallDescription;
            productToAddOrUpdate.Details = viewModel.Details?
                .Where(d => !string.IsNullOrEmpty(d.Key))
                .ToDictionary(
                    d => d.Key ?? string.Empty,
                    d => (object?)d.Value ?? string.Empty
                ) ?? [];
            productToAddOrUpdate.Price = viewModel.Price;
            productToAddOrUpdate.Stock = viewModel.Stock;
            productToAddOrUpdate.ProductImages = _productImageService.GetList().Where(x => x.ProductId == viewModel.Id).ToList();
            productToAddOrUpdate.CategoryId = viewModel.CategoryId;
            productToAddOrUpdate.IsActive = true;
            if (productToAddOrUpdate.ProductImages.Count > 0)
            {
                foreach (var i in viewModel.ProductImages)
                {
                    var image = productToAddOrUpdate.ProductImages.FirstOrDefault(x => x.Id == i.Id);
                    if (image != null)
                    {
                        image.Order = i.Order;
                    }
                }
            }

            try
            {                
                if (viewModel.Id == Guid.Empty)
                {
                    Add(productToAddOrUpdate);
                }
                else
                {
                    Update(productToAddOrUpdate);
                }

                if (viewModel.ImageUploadFiles != null && viewModel.ImageUploadFiles.Count > 0)
                {
                    foreach (var file in viewModel.ImageUploadFiles)
                    {
                        if (file.ImageUploadFile != null && file.ImageUploadFile.Length > 0)
                        {
                            var name = $"{Guid.NewGuid()}{Path.GetExtension(file.ImageUploadFile.FileName)}";
                            var imagePath = _productImageService.SaveFile(file.ImageUploadFile, name).Result;
                            var productImage = new ProductImage()
                            {
                                Id = Guid.NewGuid(),
                                ProductId = productToAddOrUpdate.Id,
                                ImagePath = imagePath,
                                Order = file.Order ?? 0
                            };
                            _productImageService.Add(productImage);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }

            return productToAddOrUpdate.Id;
        }
    }

    public class ProductImageService : BaseService<ProductImage>, IProductImageService
    {       
        public List<ProductImageViewModel> GetProductImages(Guid productId)
        {
            var imagesList = GetList().Where(x => x.ProductId == productId && !string.IsNullOrEmpty(x.ImagePath)).OrderBy(x => x.Order).ToList();

            return imagesList.Count > 0 ? [.. imagesList.Select(x=> new ProductImageViewModel()
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                Order = x.Order
            })] : [];
        }


        public async Task<string> SaveFile(IFormFile file, string name)
        {
            
            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @".\..\Ecommerce\wwwroot\images\products"));
            var relativePath = "~/images/products/";


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filename = name.Trim().Replace(" ", "");
            using (var fileStream = new FileStream(Path.Combine(path, filename), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine(relativePath + filename);
        }
    }

}
