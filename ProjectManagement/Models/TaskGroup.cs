using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Models
{
    public class TaskGroup
    {
        public int Id { get; set; }
        [Required] 
        public string Title { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public IList<ProjectTask> Tasks { get; set; }
    }
}
