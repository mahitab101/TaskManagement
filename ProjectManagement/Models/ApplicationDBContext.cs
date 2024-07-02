using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Configuration;

namespace ProjectManagement.Models
{
    public class ApplicationDBContext:IdentityDbContext<AuthUser>
    {
       public ApplicationDBContext(DbContextOptions options) : base(options) { }
       public DbSet<Project> Projects { get; set; }
       public DbSet<ProjectTeam> ProjectTeams { get; set; }
       public DbSet<TaskGroup> TaskGroups { get; set; }
       public DbSet<ProjectTask> ProjectTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<Project>().HasQueryFilter(b => !b.IsDeleted);
        }
    }
}