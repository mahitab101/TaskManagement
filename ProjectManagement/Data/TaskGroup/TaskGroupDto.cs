using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Data.TaskGroup
{
    public class TaskGroupDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
   
        public int ProjectId { get; set; }
    }
}
