namespace CharApp.Models;
public class Message
{
    public Message()
    {
        MessageId = Guid.NewGuid().ToString();
    }
    public string MessageId { get; set; }
    public string RoomId { get; set; }
    public ChatRoom ChatRoom { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public IEnumerable<Attachment> Attachments { get; set; }
}
