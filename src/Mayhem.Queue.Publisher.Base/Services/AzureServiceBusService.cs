using Mayhem.Queue.Interfaces;
using Mayhem.Queue.Publisher.Base.Interfaces;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mayhem.Queue.Publisher.Base.Services
{
    public class AzureServiceBusService : IQueueService
    {
        private readonly IQueueClient queueClient;

        public AzureServiceBusService(IQueueConfiguration queueConfiguration)
        {
            queueClient = new QueueClient(queueConfiguration.ServiceBusConnectionString, queueConfiguration.QueueName);
        }

        public async Task<bool> PublishMessage(object message)
        {
            if (message == null)
            {
                return false;
            }

            Message messageBody = ToMessage(JsonConvert.SerializeObject(message));

            await queueClient.SendAsync(messageBody);

            return true;
        }

        private static Message ToMessage(string json)
        {
            byte[] body = Encoding.UTF8.GetBytes(json);

            Message message = new()
            {
                Body = body,
                ContentType = "text/plain"
            };

            return message;
        }
    }
}
