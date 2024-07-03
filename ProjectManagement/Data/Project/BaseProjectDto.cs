using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Data.Project
{
    public abstract class BaseProjectDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
    }
}
