using Mayhem.Queue.Interfaces;
using Mayhem.Queue.Publisher.Base.Interfaces;
using Mayhem.Queue.Publisher.Base.Services;
using Mayhem.Queue.Publishers;

namespace Mayhem.Queue.Publishers
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
