namespace Mayhem.Queue.Interfaces
{
    /// <summary>
    /// Queue Configuration
    /// </summary>
    public interface IQueueConfiguration
    {
        /// <summary>
        /// Gets or sets the service bus connection string.
        /// </summary>
        /// <value>
        /// The service bus connection string.
        /// </value>
        string ServiceBusConnectionString { get; set; }
        /// <summary>
        /// Gets or sets the name of the queue.
        /// </summary>
        /// <value>
        /// The name of the queue.
        /// </value>
        string QueueName { get; set; }
    }
}
