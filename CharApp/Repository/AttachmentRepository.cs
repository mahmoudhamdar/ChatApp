using CharApp.Data;
using CharApp.Models;
using CharApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CharApp.Repository;

public class AttachmentRepository:Repository<Attachment>,IAttachmentRepository
{
    public AttachmentRepository(ChatAppContext chatAppContext) : base(chatAppContext)
    {
        
    }

    public async Task UpdateAsync(string id, Attachment entity)
    {
        var attachment = GetAsync(p => p.AttachmentId .Equals(id)).Result.FirstOrDefault();
        attachment.MessageId=entity.MessageId;
        attachment.Message=entity.Message;
        attachment.FilePath=entity.FilePath;
        attachment.FileType=entity.FileType;
        attachment.CreatedAt=entity.CreatedAt;

        await SaveAsync();
    }
}