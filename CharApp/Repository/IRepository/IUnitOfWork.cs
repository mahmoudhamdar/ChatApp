namespace CharApp.Repository.IRepository;

public interface IUnitOfWork
{
    
    public IAttachmentRepository AttachmentRepository { get;  }
    public IMessageRepository MessageRepository { get;  }
    public IUserStatusRepository UserStatusRepository { get;  }
    public IUserChatRoomRepository UserChatRoomRepository { get;  }
    public IUserRepository UserRepository { get;  }
    public IChatRoomRepository ChatRoomRepository { get;  }
    
}