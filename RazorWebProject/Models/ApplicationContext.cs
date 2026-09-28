using Microsoft.EntityFrameworkCore;

namespace RazorWebProject.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}