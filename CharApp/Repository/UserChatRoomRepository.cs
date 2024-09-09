using CharApp.Data;
using CharApp.Models;
using CharApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Repository;

public class UserChatRoomRepository:Repository<UserChatRoom>,IUserChatRoomRepository
{
    public UserChatRoomRepository(ChatAppContext chatAppContext) : base(chatAppContext)
    {
        
    }

    public async Task UpdateAsync(string id, UserChatRoom entity)
    {
        var userChatRoom = GetAsync(p => p.UserChatRoomId .Equals(id)).Result.FirstOrDefault();

        userChatRoom.RoomId = entity.RoomId;
        userChatRoom.User=entity.User;
        userChatRoom.UserId=entity.UserId;
        userChatRoom.ChatRoom=entity.ChatRoom;

        await SaveAsync();
    }
}