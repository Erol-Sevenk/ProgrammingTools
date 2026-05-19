using Microsoft.EntityFrameworkCore;

namespace ErasmusMate.Models;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ErasmusTask> ErasmusTasks { get; set; }
    public DbSet<Accommodation> Accommodations { get; set; }
    public DbSet<ForumPost> ForumPosts { get; set; }
}