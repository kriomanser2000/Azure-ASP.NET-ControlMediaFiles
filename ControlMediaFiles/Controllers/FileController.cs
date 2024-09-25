using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.IO;
using ControlMediaFiles.Models;

namespace ControlMediaFiles.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly QueueServiceClient _queueServiceClient;
        private readonly UserManager<IdentityUser> _userManager;
        public FileController(BlobServiceClient blobServiceClient, QueueServiceClient queueServiceClient, UserManager<IdentityUser> userManager)
        {
            _blobServiceClient = blobServiceClient;
            _queueServiceClient = queueServiceClient;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Pls select File.");
                return View("Upload");
            }
            var userId = _userManager.GetUserId(User);
            var containerClient = _blobServiceClient.GetBlobContainerClient(userId);
            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlobClient(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }
            var queueClient = _queueServiceClient.GetQueueClient("file-processing");   
            await queueClient.SendMessageAsync(file.FileName);
            return RedirectToAction("MyFiles");
        }
        [HttpGet]
        public async Task<IActionResult> MyFiles()
        {
            var userId = _userManager.GetUserId(User);
            var files = new List<UploadedFile>();
            return View(files);
        }
    }
}