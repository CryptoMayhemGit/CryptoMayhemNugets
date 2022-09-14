using Mayhem.Queue.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.Queue.Publisher.Notification.Extensions
{
    public static class QueueExtensions
    {
        public static void AddNotificationQueuePublisher(this IServiceCollection services, string azureQueueNotificationConnectionString)
        {
            services.AddSingleton<INotificationQueuePublisher>(new NotificationQueuePublisher(new QueueConfiguration() { QueueName = QueueNames.NotificationQueue, ServiceBusConnectionString = azureQueueNotificationConnectionString }));
        }
        public static void AddItemQueuePublisher(this IServiceCollection services, string azureQueueNotificationConnectionString)
        {
            services.AddSingleton<IItemQueuePublisher>(new ItemQueuePublisher(new QueueConfiguration() { QueueName = QueueNames.ItemQueue, ServiceBusConnectionString = azureQueueNotificationConnectionString }));
        }
        public static void AddNpcQueuePublisher(this IServiceCollection services, string azureQueueNotificationConnectionString)
        {
            services.AddSingleton<INpcQueuePublisher>(new NpcQueuePublisher(new QueueConfiguration() { QueueName = QueueNames.NpcQueue, ServiceBusConnectionString = azureQueueNotificationConnectionString }));
        }
        public static void AddLandQueuePublisher(this IServiceCollection services, string azureQueueNotificationConnectionString)
        {
            services.AddSingleton<ILandQueuePublisher>(new LandQueuePublisher(new QueueConfiguration() { QueueName = QueueNames.LandQueue, ServiceBusConnectionString = azureQueueNotificationConnectionString }));
        }
    }
}
