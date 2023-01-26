using TaskTracker.DAL.Interfaces;

namespace TaskTracker.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskTrackerDbContext _context;
        private IProjectRepository _project;
        private ITaskRepository _task;

        public IProjectRepository Project => _project ??= new ProjectRepository(_context);

        public ITaskRepository Task => _task ??= new TaskRepository(_context);
        
        public TaskTrackerDbContext Context => _context;
        public UnitOfWork(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}