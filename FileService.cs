/* Name: Tahlia Roopan
 * Student Number: ST10365707
 * Module: CLDV6212
 */
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.Extensions.Configuration;
using System.IO; 
using System.Threading.Tasks;
namespace ABCRetail_CLDV6212_Part1.Services
{
    public class FileService
    {
        private readonly ShareServiceClient _shareServiceClient;
        public FileService()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=st10365707storage;AccountKey=Qtg16RTgOvPlE+xe6GidjsdZX+hAgLn/O14qtRoGRxbmpOeIcKy4YmkrSMMwWSj+mwK/vkC8Y01i+AStan1xew==;EndpointSuffix=core.windows.net";
            _shareServiceClient = new ShareServiceClient(connectionString);
        }

        public async Task UploadFileAsync(string shareName, string fileName, Stream content, string directoryName)
        {
            var shareClient = _shareServiceClient.GetShareClient(shareName);
            await shareClient.CreateIfNotExistsAsync();
            var directoryClient = shareClient.GetDirectoryClient(directoryName);
            await directoryClient.CreateIfNotExistsAsync();
            var fileClient = directoryClient.GetFileClient(fileName);
            await fileClient.CreateAsync(content.Length);
            await fileClient.UploadAsync(content);
        }

        internal Task UploadFileAsync(string v, string fileName, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}

