using Microsoft.AspNetCore.Mvc;
using TaskTracker.Interfaces;
using TaskTracker.DAL.Interfaces;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Formatter;
using TaskTracker.DAL.Models;
using Microsoft.AspNetCore.OData.Results;
using AutoMapper.QueryableExtensions;
using TaskTracker.Models.Task;
using TaskTracker.DAL.Repositories;
using TaskTracker.Models.Project;

namespace TaskTracker.Controllers
{
    public class TasksController : BaseApiController
    {
        private ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskService taskService,
            ITaskRepository taskRepository)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoTask task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _taskService.Create(task);
            
            return Created("tasks", task);
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<TodoTaskEntity> Get([FromODataUri] int key)
        {
            var query = _taskRepository.Table
                .Where(x => x.Id == key);

            return SingleResult.Create(query);
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable Get()
        {
            return _taskRepository.Table;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromODataUri] int key, [FromBody] TodoTask task)
        {
            await _taskService.Update(task);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            await _taskService.Delete(key);

            return NoContent();
        }
    }
}
