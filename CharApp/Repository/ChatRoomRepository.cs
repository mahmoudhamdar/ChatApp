using CharApp.Data;
using CharApp.Models;
using CharApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Repository;

public class ChatRoomRepository:Repository<ChatRoom>,IChatRoomRepository
{
    public ChatRoomRepository(ChatAppContext chatAppContext) : base(chatAppContext)
    {
        
    }

    public async Task UpdateAsync(string id, ChatRoom entity)
    {
        var chatRoom = GetAsync(p => p.RoomId .Equals(id)).Result.FirstOrDefault();

        chatRoom.RoomName = entity.RoomName;
        chatRoom.Messages=entity.Messages;
        chatRoom.UserChatRooms=entity.UserChatRooms;
        chatRoom.CreatedAt=entity.CreatedAt;

        await SaveAsync();
    }
}