using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Models;
public class ChatRoom
{
    public ChatRoom()
    {
        RoomId = Guid.NewGuid().ToString();
    }
    
    public string RoomId { get; set; }
    public string RoomName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public IEnumerable<UserChatRoom> UserChatRooms { get; set; }
    public IEnumerable<Message> Messages { get; set; }
}
