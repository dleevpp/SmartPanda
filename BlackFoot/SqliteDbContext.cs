using Microsoft.EntityFrameworkCore;
using BlackFoot.Models;

namespace BlackFoot
{
  public class SqliteDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Coupon>()
        .Property(p => p.Discount)
        .IsRequired();

      modelBuilder.Entity<Inquiry>()
        .Property(p => p.Title)
        .IsRequired();
      
      modelBuilder.Entity<Order>()
        .Property(p => p.CreatedAt)
        .HasDefaultValueSql("date('now')");
      modelBuilder.Entity<Order>()
        .Property(p => p.Count)
        .HasDefaultValue(0);
      modelBuilder.Entity<Order>()
        .Property(p => p.HasShipped)
        .HasDefaultValue(false);
      modelBuilder.Entity<Order>()
        .Property(p => p.IsCancelled)
        .HasDefaultValue(false);

      modelBuilder.Entity<Product>()
        .Property(p => p.Category)
        .IsRequired();
      modelBuilder.Entity<Product>()
        .Property(p => p.Name)
        .IsRequired();
      modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasDefaultValue(0);
      modelBuilder.Entity<Product>()
        .Property(p => p.Sales)
        .HasDefaultValue(0);
      modelBuilder.Entity<Product>()
        .Property(p => p.Image)
        .HasDefaultValue("/images/no_image.png");
      
      modelBuilder.Entity<Question>()
        .Property(p => p.Title)
        .IsRequired();
    
      modelBuilder.Entity<Reply>()
        .Property(p => p.Content)
        .IsRequired();
      
      modelBuilder.Entity<Role>()
        .Property(p => p.Name)
        .IsRequired();
        
      modelBuilder.Entity<User>()
        .Property(p => p.Username)
        .IsRequired();
      modelBuilder.Entity<User>()
        .Property(p => p.Password)
        .IsRequired();
      modelBuilder.Entity<User>()
        .Property(p => p.Point)
        .HasDefaultValue(1000);
    }
    private static readonly string connectionString = @"Data Source=db.sqlite";
    public DbSet<User> Users { get; set; }
  }
}
