using CourseManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Course> Courses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasIndex(c => c.Title);
            modelBuilder.Entity<Course>().HasQueryFilter(c => !c.IsDeleted);

        }
    }

}
