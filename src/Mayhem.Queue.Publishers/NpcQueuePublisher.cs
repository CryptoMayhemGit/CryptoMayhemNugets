using Mayhem.Queue.Interfaces;
using Mayhem.Queue.Publisher.Base.Interfaces;
using Mayhem.Queue.Publisher.Base.Services;
using Mayhem.Queue.Publishers;

namespace Mayhem.Queue.Publishers
{
    public class NpcQueuePublisher : AzureServiceBusService, INpcQueuePublisher
    {
        public NpcQueuePublisher(IQueueConfiguration queueConfiguration) : base(queueConfiguration)
        {
        }
    }

    public interface INpcQueuePublisher : IQueueService
    {

    }
}
