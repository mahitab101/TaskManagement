using AutoMapper;
using ProjectManagement.Data.Project;
using ProjectManagement.Data.TaskGroup;
using ProjectManagement.Models;

namespace ProjectManagement.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Project, CreateProjectDto>().ReverseMap();   
            CreateMap<Project,GetProjectDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, BaseProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();

            CreateMap<TaskGroup,TaskGroupDto>().ReverseMap();
            CreateMap<TaskGroup, CreateTaskGroupDto>().ReverseMap();
        }
    }
}
