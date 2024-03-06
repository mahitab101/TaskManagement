using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Status { get; set; }
        public int Person { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey(nameof(GroupId))]
        public int GroupId { get; set; }
        public TaskGroup TaskGroup { get; set; }
        public IList<ProjectTeam> ProjectTeams { get; set; }
    }
}
