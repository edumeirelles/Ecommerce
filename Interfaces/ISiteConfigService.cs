using DAL.Models;

namespace Ecommerce.Interfaces
{
    public interface ISiteConfigService : IBaseService<SiteConfig>, IDisposable
    {
        SiteConfig GetSiteConfig(string siteKey);
    }
   
}
