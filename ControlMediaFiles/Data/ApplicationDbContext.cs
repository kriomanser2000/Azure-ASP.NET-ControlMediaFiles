using ControlMediaFiles.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControlMediaFiles.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<LoginViewModel> RegisterViewModels { get; set; }
        public DbSet<RegisterViewModel> LoginViewModels { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<FileQueue> FileQueues { get; set; }
        public DbSet<ProcessingStatus> ProcessingStatuses { get; set; }
    }
}
