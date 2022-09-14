using Mayhem.Queue.Interfaces;
using Mayhem.Queue.Publisher.Base.Interfaces;
using Mayhem.Queue.Publisher.Base.Services;

namespace Mayhem.Queue.Publisher.Notification
{
    public class ItemQueuePublisher : AzureServiceBusService, IItemQueuePublisher
    {
        public ItemQueuePublisher(IQueueConfiguration queueConfiguration) : base(queueConfiguration)
        {
        }
    }

    public interface IItemQueuePublisher : IQueueService
    {

    }
}
