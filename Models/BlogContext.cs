using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blog.db");
        }
    }
}
