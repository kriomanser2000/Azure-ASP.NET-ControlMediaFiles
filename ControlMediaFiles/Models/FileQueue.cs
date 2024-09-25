namespace ControlMediaFiles.Models
{
    public class FileQueue
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime QueuedAt { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public int MediaFileId { get; set; }
        public virtual MediaFile MediaFile { get; set; }
    }
}
