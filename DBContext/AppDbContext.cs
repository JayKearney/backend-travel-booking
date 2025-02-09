using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSet for Reviews
    public DbSet<Review> Reviews { get; set; }
    // DbSet for Users
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "testuser", Password = "1234", Email="testuser@gmail.com" , Role = "User" , Token = ""}
        );
    }
}