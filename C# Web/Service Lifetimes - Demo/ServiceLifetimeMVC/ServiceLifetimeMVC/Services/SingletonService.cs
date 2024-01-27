using ServiceLifetimeMVC.Interfaces;

namespace ServiceLifetimeMVC.Services
{
    public class SingletonService : ISingletonService
    {
        private Guid instanceId;
        public SingletonService()
        {
            this.instanceId = Guid.NewGuid();
        }
        public Guid GetInstanceId()
        {
            return instanceId;
        }
    }
}
