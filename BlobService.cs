/*Name: Tahia Roopan
  Student Number: ST10365707
  Module: CLDV6212
*/
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ABCRetail_CLDV6212_Part1.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobService()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=st10365707storage;AccountKey=Qtg16RTgOvPlE+xe6GidjsdZX+hAgLn/O14qtRoGRxbmpOeIcKy4YmkrSMMwWSj+mwK/vkC8Y01i+AStan1xew==;EndpointSuffix=core.windows.net";
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task UploadBlobAsync(string containerName, string blobName, Stream content, string contentType)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlobClient(blobName);

            var blobHttpHeaders = new BlobHttpHeaders
            {
                ContentType = contentType
            };

            // Corrected overload usage
            await blobClient.UploadAsync(content, new BlobUploadOptions
            {
                HttpHeaders = blobHttpHeaders,
             
            });
        }

        internal Task UploadBlobAsync(string v, string fileName, Stream stream)
        {
            throw new NotImplementedException();
        }
    }

}

