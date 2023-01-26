using TaskTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL.Interfaces;

namespace TaskTracker.DAL.Repositories
{
    public class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(TaskTrackerDbContext dbContext) : base(dbContext)
        {

        }

        public IQueryable<ProjectEntity> GetProjectWithTasks(int id)
        {
            return Context.Projects
                .Include(p => p.Tasks)
                .Where(p => p.Id == id);
        }
    }
}
