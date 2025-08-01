using DAL.Models;
using DAL.ViewModels;

namespace DAL.Interfaces
{
    public interface ISiteConfigService : IBaseService<SiteConfig>, IDisposable
    {
        SiteConfigViewModel GetSiteConfig(string siteKey);
    }
   
}
