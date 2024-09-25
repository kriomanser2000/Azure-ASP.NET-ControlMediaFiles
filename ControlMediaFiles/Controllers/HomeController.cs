using ControlMediaFiles.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControlMediaFiles.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult Upload()
        {
            return View(new FileUploadViewModel());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload(FileUploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                //save to Blob Storage
                //save to Queue Storage

                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}