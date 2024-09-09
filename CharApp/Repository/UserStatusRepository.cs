using CharApp.Data;
using CharApp.Models;
using CharApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Repository;

public class UserStatusRepository:Repository<UserStatus>,IUserStatusRepository
{
    public UserStatusRepository(ChatAppContext chatAppContext) : base(chatAppContext)
    {
        
    }

    public async Task UpdateAsync(string id, UserStatus entity)
    {
        var userStatus = GetAsync(p => p.UserId == id).Result.FirstOrDefault();
       
        userStatus.Status=entity.Status;
        userStatus.User=entity.User;
        userStatus.LastActive=entity.LastActive;
       

        await SaveAsync();
    }
}