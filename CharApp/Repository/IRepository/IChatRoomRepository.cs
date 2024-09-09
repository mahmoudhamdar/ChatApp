using CharApp.Models;

namespace CharApp.Repository.IRepository;

public interface IChatRoomRepository:IRepository<ChatRoom>
{
    public Task UpdateAsync(string id ,ChatRoom entity);
}