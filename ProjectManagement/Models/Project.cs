using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models
{
    public class Project
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public IList<TaskGroup> TaskGroups { get; set; }
    }
}
