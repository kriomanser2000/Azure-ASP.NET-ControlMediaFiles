using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ControlMediaFiles.Models
{
    public class FileUploadViewModel
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
