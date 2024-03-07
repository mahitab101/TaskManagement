using ProjectManagement.Contracts;
using ProjectManagement.Models;

namespace ProjectManagement.Repositries
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
