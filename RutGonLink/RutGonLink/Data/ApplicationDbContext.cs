using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RutGonLink.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
  {
    public DbSet<Link> Links { get; set; }
    public DbSet<LinkAnalytic> LinkAnalytics { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Cấu hình bảng, cột, khóa chính, khóa ngoại, ràng buộc, v.v.
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Link>()
        .HasIndex(code => code.ShortCode)
        .IsUnique();
    }
  }
}