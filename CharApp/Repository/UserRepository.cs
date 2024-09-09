using CharApp.Data;
using CharApp.Models;
using CharApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Repository;

public class UserRepository:Repository<User>,IUserRepository
{
    public UserRepository(ChatAppContext chatAppContext) : base(chatAppContext)
    {
        
    }

    public async Task UpdateAsync(string id, User entity)
    {
        var user = GetAsync(p => p.Id .Equals(id) ).Result.FirstOrDefault();
        user.LastLogin=entity.LastLogin;
        user.UserChatRooms=entity.UserChatRooms;
        user.Email=entity.Email;
        user.UserName=entity.UserName;
        user.CreatedAt=entity.CreatedAt;
        user.Messages=entity.Messages;
        user.UpdatedAt=entity.UpdatedAt; 
        user.PasswordHash=entity.PasswordHash;
        user.UserStatus = entity.UserStatus;
        
        await SaveAsync();
    }

}