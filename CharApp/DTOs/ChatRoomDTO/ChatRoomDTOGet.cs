using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Models;
public class ChatRoomDTOGet
{
    public string RoomId { get; set; }
    public string RoomName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   
}
