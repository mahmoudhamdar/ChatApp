using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace CharApp.Models;

public class User:IdentityUser
{
   
    
      
      
        public string Email { get; set; }= "";
      
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }

        public IEnumerable<UserChatRoom> UserChatRooms { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public UserStatus UserStatus { get; set; }
        
    

}
