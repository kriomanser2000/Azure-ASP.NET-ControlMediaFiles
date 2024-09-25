using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace ControlMediaFiles.Controllers
{
    public class FileProcessingService : BackgroundService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileProcessingService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {               
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}