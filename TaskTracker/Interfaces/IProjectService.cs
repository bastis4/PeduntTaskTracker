using TaskTracker.DAL.Models;
using TaskTracker.Models.Project;

namespace TaskTracker.Interfaces
{
    public interface IProjectService
    {
        Task Create(Project project);
        Task Update(Project project);
        Task Delete(int id);
    }
}