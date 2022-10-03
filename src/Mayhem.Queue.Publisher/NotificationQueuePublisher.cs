using Mayhem.Queue.Interfaces;
using Mayhem.Queue.Publisher.Base.Interfaces;
using Mayhem.Queue.Publisher.Base.Services;

namespace Mayhem.Queue.Publisher
{
    public class NotificationQueuePublisher : AzureServiceBusService, INotificationQueuePublisher
    {
        public NotificationQueuePublisher(IQueueConfiguration queueConfiguration) : base(queueConfiguration)
        {
        }
    }

    public interface INotificationQueuePublisher : IQueueService
    {

    }
}
