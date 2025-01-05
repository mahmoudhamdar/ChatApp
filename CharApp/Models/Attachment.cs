using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharApp.Models;
public class Attachment
{
    public Attachment()
    {
        AttachmentId = Guid.NewGuid().ToString();
    }
   
    public string AttachmentId { get; set; }
    public string MessageId { get; set; }
   
    public Message Message { get; set; }
    public string FilePath { get; set; }
    public string FileType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
