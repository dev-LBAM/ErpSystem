using Microsoft.EntityFrameworkCore;
using ErpSystem.Domain.Catalog;
using ErpSystem.Domain.Product;
using ErpSystem.Domain.Product.Lots;

namespace ErpSystem.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Lot> Lots { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2); // 18 dígitos no total, com 2 depois da vírgula.
    }
}