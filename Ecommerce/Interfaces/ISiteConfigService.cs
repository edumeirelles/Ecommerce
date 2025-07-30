using DAL.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.Interfaces
{
    public interface ISiteConfigService : IBaseService<SiteConfig>, IDisposable
    {
        SiteConfigViewModel GetSiteConfig(string siteKey);
    }
   
}
