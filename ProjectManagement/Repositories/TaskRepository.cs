using Microsoft.EntityFrameworkCore;
using ProjectManagement.Contracts;
using ProjectManagement.Models;

namespace ProjectManagement.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public TaskRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<IEnumerable<ProjectTask>> GetAllTasksAsync()
        {
            return await _dBContext.ProjectTasks.OrderBy(t => t.Id).ToListAsync();
        }

        public async Task<ProjectTask> GetTaskByIdAsync(int? id)
        {
           return await _dBContext.ProjectTasks.Where(t=>t.Id == id).FirstOrDefaultAsync();
        }
    }
}
