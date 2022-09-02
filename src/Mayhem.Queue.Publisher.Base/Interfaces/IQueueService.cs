using System.Threading.Tasks;

namespace Mayhem.Queue.Publisher.Base.Interfaces
{
    /// <summary>
    /// Queue Service
    /// </summary>
    public interface IQueueService
    {
        /// <summary>
        /// Publishes the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task<bool> PublishMessage(object message);
    }
}
