using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace Ecommerce.Data
{
    
public class Context : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Ecommerce"));
               
            }       
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            modelBuilder.Entity<Product>()
                .Property(p => p.Details)
                .HasConversion(
                    dict => JsonSerializer.Serialize(dict, jsonOptions),
                    json => JsonSerializer.Deserialize<Dictionary<string, object>>(json, jsonOptions)
                )
                .Metadata
                .SetValueComparer(new ValueComparer<Dictionary<string, object>?>(
                    (left, right) =>
                        JsonSerializer.Serialize(left, jsonOptions)
                        == JsonSerializer.Serialize(right, jsonOptions),
                    dict => dict == null
                        ? 0
                        : dict.Aggregate(0, (h, kv) =>
                            HashCode.Combine(h, kv.Key.GetHashCode(), kv.Value != null ? kv.Value.GetHashCode() : 0)),
                    dict => dict == null
                        ? null
                        : new Dictionary<string, object>(dict)
                ));

            modelBuilder.Entity<Product>().Property(p => p.Details).HasColumnType("nvarchar(max)");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SiteConfig> SiteConfig { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
               
}
