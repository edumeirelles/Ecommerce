namespace DAL.ViewModels
{
    public class SiteConfigViewModel
    {
        public Guid? Id { get; set; }
        public string? SiteName { get; set; }
        public string? SiteUrl { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? Address { get; set; }
        public string? LogoPath { get; set; }
        public string? CssPath { get; set; }
        public string? FaviconPath { get; set; }
    }
}
