using System.ComponentModel.DataAnnotations;

namespace CharApp.Models;
public class UserStatus
{
    
    public string UserId { get; set; }
    public User User { get; set; }
    public string Status { get; set; }
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
}
