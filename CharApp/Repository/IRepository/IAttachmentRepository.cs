using CharApp.Models;

namespace CharApp.Repository.IRepository;

public interface IAttachmentRepository:IRepository<Attachment>
{
    public Task UpdateAsync(string id ,Attachment entity);
}