using TaskTracker.Models.Task;

namespace TaskTracker.Events.Integration
{
    public class TaskCreatedIntegrationEvent : IntegrationEvent
    {
        public TaskCreatedIntegrationEvent(TodoTask task)
        {
            Task = task;
        }

        public TodoTask Task { get; }
    }
}
