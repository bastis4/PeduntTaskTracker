using TaskTracker.Models.Task;

namespace TaskTracker.Events.Integration
{
    public class TaskUpdatedIntegrationEvent : IntegrationEvent
    {
        public TaskUpdatedIntegrationEvent(TodoTask task)
        {
            Task = task;
        }

        public TodoTask Task { get; }
    }
}
