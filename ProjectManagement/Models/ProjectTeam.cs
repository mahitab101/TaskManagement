using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models
{
    public class ProjectTeam
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}