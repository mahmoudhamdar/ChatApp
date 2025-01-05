using CharApp.Models;

namespace CharApp.Repository.IRepository;

public interface IUserStatusRepository:IRepository<UserStatus>
{
    public Task UpdateAsync(string id ,UserStatus entity);
}