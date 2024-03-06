namespace ProjectManagement.Data.TaskGroup
{
    public class CreateTaskGroupDto
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProjectId { get; set; }
    }
}
