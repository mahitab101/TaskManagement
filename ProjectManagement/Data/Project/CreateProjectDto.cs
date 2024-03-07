using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Data.Project
{
    public class CreateProjectDto:BaseProjectDto
    {
        public bool IsDeleted { get; set; } = false;
    }
}
