using TaskTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL.Interfaces;
using TodoTaskEntity = TaskTracker.DAL.Models.TodoTaskEntity;

namespace TaskTracker.DAL.Repositories
{
    public class TaskRepository : BaseRepository<TodoTaskEntity>, ITaskRepository
    {
        public TaskRepository(TaskTrackerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
