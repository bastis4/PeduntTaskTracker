using AutoMapper;
using AutoMapper.QueryableExtensions;
using TaskTracker.DAL.Interfaces;
using TaskTracker.DAL.Models;
using TaskTracker.Events.Integration;
using TaskTracker.Interfaces;
using TaskTracker.Models.Task;

namespace TaskTracker.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIntegrationService _integrationService;

        public TaskService(IUnitOfWork repository, IMapper mapper, IIntegrationService integrationService)
        {
            _unitOfWork = repository;
            _mapper = mapper;
            _integrationService = integrationService;
        }

        public async Task Create(TodoTask task)
        {
            var entity = _mapper.Map<TodoTaskEntity>(task);
            await _unitOfWork.Task.AddRecord(entity);
            await _unitOfWork.SaveAsync();

            task.Id = entity.Id;

            _integrationService.Publish(new TaskCreatedIntegrationEvent(task));
        }

        public async Task Update(TodoTask task)
        {
            var entity = _mapper.Map<TodoTaskEntity>(task);

            _unitOfWork.Task.UpdateRecord(entity);
            await _unitOfWork.SaveAsync();

            _integrationService.Publish(new TaskUpdatedIntegrationEvent(task));
        }

        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.Task.GetRecord(id);

            _unitOfWork.Task.DeleteRecord(entity);
            await _unitOfWork.SaveAsync();

            _integrationService.Publish(new TaskDeletedIntegrationEvent(id));
        }
    }
}