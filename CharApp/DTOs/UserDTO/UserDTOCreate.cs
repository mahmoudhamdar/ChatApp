using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CharApp.Models;

public class UserDTOCreate
{
   
    
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
        
    

}
