using DAL.Interfaces;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Ecommerce.Controllers
{
    public class BaseController(ICategoryService categoryService, IProductService productService, ISiteConfigService siteConfigService) : Controller
    {
        protected IProductService _productService = productService;
        protected ICategoryService _categoryService = categoryService;
        protected ISiteConfigService _siteConfigService = siteConfigService;       

        public SiteConfigViewModel? siteConfig { get; set; }
        public SiteConfigViewModel? SiteConfig
        {
            get
            {
                if (siteConfig != null)
                    return siteConfig;
                if (string.IsNullOrEmpty(Request.Cookies["SiteConfig"]))
                    return null;
                return JsonSerializer.Deserialize<SiteConfigViewModel>(Request.Cookies["SiteConfig"]!);
            }
            set
            {
                if (value == null)
                    Response.Cookies.Delete("SiteConfig");  
                else
                    Response.Cookies.Append("SiteConfig", JsonSerializer.Serialize(value), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(30),
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    }); 
                siteConfig = value;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var pathBase = Request.PathBase.Value?.Split("/").Length > 1 ? Request.PathBase.Value.Split("/")[Request.PathBase.Value.Split("/").Length - 1] : Request.PathBase.Value?.Replace("/", "");

            if (SiteConfig == null || string.IsNullOrEmpty(SiteConfig.SiteName) || SiteConfig.SiteName.ToUpper() != pathBase?.ToUpper())
            {  
                SiteConfig = _siteConfigService.GetSiteConfig(pathBase!);
            }

            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            TempData["SiteConfig"] = JsonSerializer.Serialize(SiteConfig);
            ViewBag.Categories = _categoryService.GetCategories();

            base.OnActionExecuted(context);
        }
    }
}
