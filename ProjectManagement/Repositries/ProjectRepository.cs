using ProjectManagement.Contracts;
using ProjectManagement.Models;

namespace ProjectManagement.Repositries
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly ApplicationDBContext _context;
        public ProjectRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
