using DAL.Models;
using Ecommerce.Interfaces;
using Ecommerce.ViewModels;


namespace Ecommerce.Services
{
    public class SiteConfigService : BaseService<SiteConfig>, ISiteConfigService
    {       

        public SiteConfigViewModel GetSiteConfig(string siteKey)
        {
            var siteConfig = GetList().FirstOrDefault(x => x.SiteName == siteKey);
            return new SiteConfigViewModel
            {
                Address = siteConfig?.Address,
                ContactEmail = siteConfig?.ContactEmail,
                ContactPhone = siteConfig?.ContactPhone,
                CssPath = siteConfig?.CssPath,
                FaviconPath = siteConfig?.FaviconPath,
                LogoPath = siteConfig?.LogoPath,
                SiteName = siteConfig?.SiteName,
                SiteUrl = siteConfig?.SiteUrl,
                
            } ?? throw new KeyNotFoundException($"Site configuration for '{siteKey}' not found.");
        }

       
    }
}
