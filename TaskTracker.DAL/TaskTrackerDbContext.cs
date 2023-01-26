using TaskTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using TodoTaskEntity = TaskTracker.DAL.Models.TodoTaskEntity;

namespace TaskTracker.DAL
{
    public class TaskTrackerDbContext : DbContext
    {
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<TodoTaskEntity> Tasks { get; set; }

        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
               .HasMany(e => e.Tasks);
        }*/
    }
}