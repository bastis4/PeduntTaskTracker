using TaskTracker.Models.Project;

namespace TaskTracker.Events.Integration
{
    public class ProjectUpdatedIntegrationEvent : IntegrationEvent
    {
        public ProjectUpdatedIntegrationEvent(Project project)
        {
            Project = project;
        }

        public Project Project { get; }
    }
}
