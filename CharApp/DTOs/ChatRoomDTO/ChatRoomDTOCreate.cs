using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Models;
public class ChatRoomDTOCreate
{
    
    public string RoomName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
