namespace CharApp.Models;
public class AttachmentDTOCreate
{
   
    public string MessageId { get; set; }
    public string FilePath { get; set; }
    public string FileType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
