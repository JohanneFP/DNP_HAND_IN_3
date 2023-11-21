using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class PostContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = C:\\Users\\johan\\RiderProjects\\DNP_Handin_One\\EfcDataAccess\\Post.db"); 
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);            
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(post => post.Id); //setting the key
        modelBuilder.Entity<User>().HasKey(user => user.Id); //setting the key
        modelBuilder.Entity<Post>().Property(todo => todo.Title).HasMaxLength(50); //constraint for title
    }
}