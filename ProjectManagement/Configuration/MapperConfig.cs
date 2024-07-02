using AutoMapper;
using ProjectManagement.Data.Project;
using ProjectManagement.Data.TaskGroup;
using ProjectManagement.Data.User;
using ProjectManagement.Models;

namespace ProjectManagement.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            //project
            CreateMap<Project, BaseProjectDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project,GetProjectDto>().ReverseMap();
            CreateMap<Project, CreateProjectDto>().ReverseMap();   
            CreateMap<Project, UpdateProjectDto>().ReverseMap();

            //Task Group
            CreateMap<TaskGroup,TaskGroupDto>().ReverseMap();
            CreateMap<TaskGroup, CreateTaskGroupDto>().ReverseMap();

            //User
            CreateMap<UserDto, AuthUser>().ReverseMap();
        }
    }
}
