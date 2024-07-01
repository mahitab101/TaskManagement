using ProjectManagement.Models;

namespace ProjectManagement.Contracts
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ProjectTask>> GetAllTasksAsync();
        Task<ProjectTask> GetTaskByIdAsync(int? id);
    }
}
