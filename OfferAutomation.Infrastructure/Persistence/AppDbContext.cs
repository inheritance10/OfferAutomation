using Microsoft.EntityFrameworkCore;

using OfferAutomation.Domain.Entities;

namespace OfferAutomation.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    public DbSet<Company> Companies => Set<Company>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>()
         .HasMany(c => c.Users)
         .WithOne(u => u.Company)
         .HasForeignKey(u => u.CompanyId)
         .OnDelete(DeleteBehavior.Cascade);
    }
}
