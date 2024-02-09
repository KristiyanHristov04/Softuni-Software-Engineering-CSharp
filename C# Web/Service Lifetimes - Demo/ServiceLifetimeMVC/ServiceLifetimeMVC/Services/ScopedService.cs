using ServiceLifetimeMVC.Interfaces;

namespace ServiceLifetimeMVC.Services
{
    public class ScopedService : IScopedService
    {
        private Guid instanceId;
        public ScopedService()
        {
            this.instanceId = Guid.NewGuid();
        }
        public Guid GetInstanceId()
        {
            return instanceId;
        }
    }
}
