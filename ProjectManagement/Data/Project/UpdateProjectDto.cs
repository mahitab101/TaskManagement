namespace ProjectManagement.Data.Project
{
    public class UpdateProjectDto:BaseProjectDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
