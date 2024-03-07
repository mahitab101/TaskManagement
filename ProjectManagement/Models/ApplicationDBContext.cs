using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Models
{
    public class ApplicationDBContext:DbContext
    {
       public ApplicationDBContext(DbContextOptions options) : base(options) { }
       public DbSet<Project> Projects { get; set; }
       public DbSet<ProjectTeam> ProjectTeams { get; set; }
       public DbSet<TaskGroup> TaskGroups { get; set; }
       public DbSet<ProjectTask> ProjectTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasQueryFilter(b => !b.IsDeleted);
        }
    }
}