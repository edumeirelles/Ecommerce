using Ecommerce.Data;
using Ecommerce.Interfaces;
using Ecommerce.Models;

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
