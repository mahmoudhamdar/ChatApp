namespace CharApp.Repository.IRepository;
using CharApp.Models;
public interface IUserRepository:IRepository<User>
{
    public Task UpdateAsync(string id ,User entity);
}