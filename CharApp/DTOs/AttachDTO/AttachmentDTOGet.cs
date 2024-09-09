namespace CharApp.Models;

public class AttachmentDTOGet
{
    
    public string AttachmentId { get; set; }
    public string FilePath { get; set; }
    public string FileType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}