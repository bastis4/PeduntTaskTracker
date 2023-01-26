using TaskTracker.Models.Project;

namespace TaskTracker.Events.Integration
{
    public class ProjectDeletedIntegrationEvent : IntegrationEvent
    {
        public ProjectDeletedIntegrationEvent(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId { get; }
    }
}
