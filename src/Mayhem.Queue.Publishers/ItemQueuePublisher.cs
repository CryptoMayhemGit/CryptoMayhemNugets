using Mayhem.Queue.Interfaces;
using Mayhem.Queue.Publisher.Base.Interfaces;
using Mayhem.Queue.Publisher.Base.Services;
using Mayhem.Queue.Publishers;

namespace Mayhem.Queue.Publishers
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
