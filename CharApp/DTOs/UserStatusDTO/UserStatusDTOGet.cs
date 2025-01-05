using System.ComponentModel.DataAnnotations;

namespace CharApp.Models;
public class UserStatusDTOGet
{
    
    public string UserId { get; set; }
   
    public string Status { get; set; }
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
}
