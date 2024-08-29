/* Name: Tahlia Roopan
 * Student Number: ST10365707
 * Module: CLDV6212
 */
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
namespace ABCRetail_CLDV6212_Part1.Services
{
    public class QueueService
    {
        private readonly QueueServiceClient _queueServiceClient;
        public QueueService()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=st10365707storage;AccountKey=Qtg16RTgOvPlE+xe6GidjsdZX+hAgLn/O14qtRoGRxbmpOeIcKy4YmkrSMMwWSj+mwK/vkC8Y01i+AStan1xew==;EndpointSuffix=core.windows.net";
            _queueServiceClient = new QueueServiceClient(connectionString);
        }

        public async Task SendMessageAsync(string queueName, string message)
        {
            var queueClient = _queueServiceClient.GetQueueClient(queueName);
            await queueClient.CreateIfNotExistsAsync();
            await queueClient.SendMessageAsync(message);
        }
    }
}

