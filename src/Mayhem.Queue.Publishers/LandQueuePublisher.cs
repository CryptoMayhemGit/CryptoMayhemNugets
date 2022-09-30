using Mayhem.Queue.Interfaces;
using Mayhem.Queue.Publisher.Base.Interfaces;
using Mayhem.Queue.Publisher.Base.Services;
using Mayhem.Queue.Publishers;

namespace Mayhem.Queue.Publishers
{
    public class LandQueuePublisher : AzureServiceBusService, ILandQueuePublisher
    {
        public LandQueuePublisher(IQueueConfiguration queueConfiguration) : base(queueConfiguration)
        {
        }
    }

    public interface ILandQueuePublisher : IQueueService
    {

    }
}
