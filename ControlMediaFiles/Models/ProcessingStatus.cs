namespace ControlMediaFiles.Models
{
    public class ProcessingStatus
    {
        public int Id { get; set; }
        public int MediaFileId { get; set; }
        public virtual MediaFile MediaFile { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
