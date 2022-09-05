using Mayhem.Queue.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayhem.Queue.Publisher.Notification.Extensions
{
    public static class QueueExtensions
    {
        public static void AddPublisher(this IServiceCollection services, string azureQueueNotificationConnectionString)
        {
            NotificationQueuePublisher notificationQueuePublisher = new(new QueueConfiguration() { QueueName = QueueNames.NotificationQueue, ServiceBusConnectionString = azureQueueNotificationConnectionString });
            services.AddSingleton<INotificationQueuePublisher>(notificationQueuePublisher);
        }
    }
}
