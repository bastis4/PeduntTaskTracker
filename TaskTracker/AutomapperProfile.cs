using AutoMapper;
using TaskTracker.DAL.Models;
using TaskTracker.Models.Project;

namespace TaskTracker
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectEntity, Project>().ReverseMap();
            CreateMap<Models.Task.TodoTask, TodoTaskEntity>().ReverseMap();
        }
    }
}
