namespace TaskTracker.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProjectRepository Project { get; }
        ITaskRepository Task { get; }
        Task SaveAsync();
        Task DisposeAsync();
    }
}
