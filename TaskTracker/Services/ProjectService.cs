using AutoMapper;
using Azure.Core;
using TaskTracker.DAL.Interfaces;
using TaskTracker.DAL.Models;
using TaskTracker.Events.Integration;
using TaskTracker.Interfaces;
using TaskTracker.Models.Project;

namespace TaskTracker.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIntegrationService _integrationService;

        public ProjectService(IUnitOfWork repository, IMapper mapper, IIntegrationService integrationService)
        {
            _unitOfWork = repository;
            _mapper = mapper;
            _integrationService = integrationService;
        }

        public async Task Create(Project project)
        {
            var entity = _mapper.Map<ProjectEntity>(project);

            await _unitOfWork.Project.AddRecord(entity);
            await _unitOfWork.SaveAsync();

            project.Id = entity.Id;

            _integrationService.Publish(new ProjectCreatedIntegrationEvent(project));
        }

        public async Task Update(Project project)
        {
            var entity = _mapper.Map<ProjectEntity>(project);

            _unitOfWork.Project.UpdateRecord(entity);
            await _unitOfWork.SaveAsync();

            _integrationService.Publish(new ProjectUpdatedIntegrationEvent(project));
        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.Project.GetRecord(id);
            _unitOfWork.Project.DeleteRecord(entity);
            await _unitOfWork.SaveAsync();

            _integrationService.Publish(new ProjectDeletedIntegrationEvent(id));
        }
    }
}