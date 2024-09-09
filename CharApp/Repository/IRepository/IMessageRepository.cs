namespace CharApp.Repository.IRepository;
using CharApp.Models;
public interface IMessageRepository:IRepository<Message>
{
    public Task UpdateAsync(string id ,Message entity);
}