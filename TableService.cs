/*Name: Tahia Roopan
  Student Number: ST10365707
  Module: CLDV6212
*/
using Azure.Data.Tables;
using ABCRetail_CLDV6212_Part1.Models;
using System.Threading.Tasks;
namespace ABCRetail_CLDV6212_Part1.Services
{
    public class TableService
    {
        private readonly TableClient _tableClient;
        public TableService(IConfiguration configuration)
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=st10365707storage;AccountKey=Qtg16RTgOvPlE+xe6GidjsdZX+hAgLn/O14qtRoGRxbmpOeIcKy4YmkrSMMwWSj+mwK/vkC8Y01i+AStan1xew==;EndpointSuffix=core.windows.net";
            var serviceClient = new TableServiceClient(connectionString);
            _tableClient = serviceClient.GetTableClient("CustomerProfiles");
            _tableClient.CreateIfNotExists();
        }

        public async Task AddEntityAsync(CustomerProfile profile)
        {
            await _tableClient.AddEntityAsync(profile);
        }
    }
}

