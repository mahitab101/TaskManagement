using ProjectManagement.Contracts;
using ProjectManagement.Models;

namespace ProjectManagement.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Project> Projects { get; }
        IBaseRepository<TaskGroup> TaskGroups { get; }
        int Complete();
    }
}
