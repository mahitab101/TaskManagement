using Microsoft.EntityFrameworkCore;
using ProjectManagement.Contracts;
using ProjectManagement.Data.Project;
using ProjectManagement.Models;
using System.Threading.Tasks;

namespace ProjectManagement.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly ApplicationDBContext _context;

        public ProjectRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Project> GetDetails(int projectId)
        {
            return await _context.Projects
                .Include(p => p.TaskGroups)
                .FirstOrDefaultAsync(p => p.Id == projectId && !p.IsDeleted);
        }

      
    }
}
