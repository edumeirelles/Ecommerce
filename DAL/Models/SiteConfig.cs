namespace DAL.Models
{
    public class SiteConfig : EntityBase
    {        
        public required string SiteName { get; set; }
        public required string SiteUrl { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? Address { get; set; }
        public string? LogoPath { get; set; }
        public string? CssPath { get; set; }
        public string? FaviconPath { get; set; }
        
    }    
}
