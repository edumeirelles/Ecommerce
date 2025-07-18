using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface ISiteConfigService : IBaseService<SiteConfig>, IDisposable
    {
        public SiteConfig GetSiteConfig(string siteKey);
    }
   
}
