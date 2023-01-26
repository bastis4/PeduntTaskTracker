using TaskTracker.Models.Task;

namespace TaskTracker.Interfaces
{
    public interface ITaskService
    {
        Task Create(TodoTask task);
        Task Update(TodoTask task);
        Task Delete(int id);
    }
}