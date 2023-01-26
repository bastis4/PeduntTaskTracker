using TaskTracker.Models.Task;

namespace TaskTracker.Events.Integration
{
    public class TaskDeletedIntegrationEvent : IntegrationEvent
    {
        public TaskDeletedIntegrationEvent(int taskId)
        {
            TaskId = taskId;
        }

        public int TaskId { get; }
    }
}
