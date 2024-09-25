namespace ControlMediaFiles.Models
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string BlobUrl { get; set; }
        public string UserId { get; set; }
        public FileProcessingStatus Status { get; set; }
    }
    public enum FileProcessingStatus
    {
        Uploaded,
        Processing,
        Completed,
        Failed
    }
}