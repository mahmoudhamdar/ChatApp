using System.Linq.Expressions;

namespace CharApp.Repository.IRepository;

public interface IRepository<T>
{

  public Task<IEnumerable<T>> GetallAsync();
  public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter=null);
  public Task AddAsync(T entity);
  
  public Task DeleteAsync(T entity);

  public Task SaveAsync();





}