using ProjectManagement.Data.TaskGroup;
using ProjectManagement.Models;

namespace ProjectManagement.Data.Project
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public IList<TaskGroupDto> TaskGroups { get; set; }
    }
}
