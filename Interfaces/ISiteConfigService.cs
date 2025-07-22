using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface ISiteConfigService : IBaseService<SiteConfig>, IDisposable
    {
        SiteConfig GetSiteConfig(string siteKey);
    }
   
}
