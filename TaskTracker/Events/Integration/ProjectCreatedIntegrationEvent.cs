using TaskTracker.Models.Project;

namespace TaskTracker.Events.Integration
{
    public class ProjectCreatedIntegrationEvent : IntegrationEvent
    {
        public ProjectCreatedIntegrationEvent(Project project)
        {
            Project = project;
        }

        public Project Project { get; }
    }
}