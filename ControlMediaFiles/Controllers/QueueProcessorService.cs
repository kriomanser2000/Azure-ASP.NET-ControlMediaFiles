using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using System.Threading;
using System.Threading.Tasks;

namespace ControlMediaFiles.Controllers
{
    //public class QueueProcessorService : Controller
    //{
    //    private readonly QueueClient _queueClient;
    //    private readonly BlobServiceClient _blobServiceClient;
    //    public QueueProcessorService(QueueClient queueClient, BlobServiceClient blobServiceClient)
    //    {
    //        _queueClient = queueClient;
    //        _blobServiceClient = blobServiceClient;
    //    }
    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        while (!stoppingToken.IsCancellationRequested)
    //        {
    //            var message = await _queueClient.ReceiveMessageAsync();
    //            if (message.Value != null)
    //            {
    //                var fileName = message.Value.MessageText;
    //                await ProcessFileAsync(fileName);
    //                await _queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt);
    //            }
    //            await Task.Delay(1000, stoppingToken);
    //        }
    //    }
    //    private async Task ProcessFileAsync(string fileName)
    //    {
    //        var blobClient = _blobServiceClient.GetBlobContainerClient("container-name").GetBlobClient(fileName);
    //    }
    //}
}