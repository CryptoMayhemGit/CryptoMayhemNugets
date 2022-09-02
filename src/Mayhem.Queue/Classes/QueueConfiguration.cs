using Mayhem.Queue.Interfaces;

namespace Mayhem.Queue.Classes
{
    public class QueueConfiguration : IQueueConfiguration
    {
        public string ServiceBusConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
