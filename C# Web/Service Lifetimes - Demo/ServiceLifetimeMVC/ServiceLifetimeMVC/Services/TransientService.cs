using ServiceLifetimeMVC.Interfaces;

namespace ServiceLifetimeMVC.Services
{
    public class TransientService : ITransientService
    {
        private Guid instanceId;
        public TransientService()
        {
            this.instanceId = Guid.NewGuid();
        }
        public Guid GetInstanceId()
        {
            return instanceId;
        }
    }
}
