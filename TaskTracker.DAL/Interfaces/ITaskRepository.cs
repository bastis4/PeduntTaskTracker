using TodoTaskEntity = TaskTracker.DAL.Models.TodoTaskEntity;

namespace TaskTracker.DAL.Interfaces
{
    public interface ITaskRepository : IBaseRepository<TodoTaskEntity>
    {
    }
}
