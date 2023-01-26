using Microsoft.AspNetCore.Mvc;
using TaskTracker.DAL.Interfaces;
using TaskTracker.Interfaces;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Results;
using TaskTracker.DAL.Models;
using TaskTracker.Models.Project;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace TaskTracker.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private IProjectService _projectService;
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectService projectService, 
            IProjectRepository projectRepository)
        {
            _projectService = projectService;
            _projectRepository = projectRepository;
        }


        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<ProjectEntity> Get([FromODataUri] int key)
        {
            var query = _projectRepository.Table
                .Where(x => x.Id == key);

            return SingleResult.Create(query);
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable Get()
        {
            return _projectRepository.Table;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _projectService.Create(project);

            return Created("projects", project);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromODataUri] int key, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != project.Id)
            {
                return BadRequest();
            }

            await _projectService.Update(project);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            await _projectService.Delete(key);

            return NoContent();
        }
    }
}