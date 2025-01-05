using CharApp.Models;

namespace CharApp.Repository.IRepository;

public interface IUserChatRoomRepository:IRepository<UserChatRoom>
{
    public Task UpdateAsync(string id ,UserChatRoom entity);
}