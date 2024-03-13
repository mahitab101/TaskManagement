using ProjectManagement.Models;
using System.Diagnostics.Metrics;

namespace ProjectManagement.Contracts
{
    public interface IProjectRepository:IBaseRepository<Project>
    {
        Task<Project> GetDetails(int projectId);

    }
}
