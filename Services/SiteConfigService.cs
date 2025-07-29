using DAL;
using DAL.Models;
using Ecommerce.Interfaces;


namespace Ecommerce.Services
{
    public class SiteConfigService : BaseService<SiteConfig>, ISiteConfigService
    {       

        public SiteConfig GetSiteConfig(string siteKey)
        {
            return this.GetList().FirstOrDefault(x => x.SiteName == siteKey)
                ?? throw new KeyNotFoundException($"Site configuration for '{siteKey}' not found.");
        }
    }
}
