using TaskTracker.Events.Integration;

namespace TaskTracker.Interfaces
{
    public interface IIntegrationService
    {
        public void Publish(IntegrationEvent integrationEvent);
    }
}