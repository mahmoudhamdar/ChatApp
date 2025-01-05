using CharApp.Data;
using CharApp.Models;
using CharApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Repository;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(ChatAppContext chatAppContext) : base(chatAppContext)
    {
        
    }

    public async Task UpdateAsync(string id,Message entity)
    {

        var message = GetAsync(p => p.MessageId .Equals(id)).Result.FirstOrDefault();
      
        message.Attachments = entity.Attachments;
        message.ChatRoom = entity.ChatRoom;
        message.Content = entity.Content;
        message.CreatedAt = entity.CreatedAt;
        message.User = entity.User;
        message.RoomId = entity.RoomId;
        message.UserId = entity.UserId;

        await SaveAsync();
    }
}