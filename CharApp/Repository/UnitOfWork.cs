using CharApp.Data;
using CharApp.Repository.IRepository;

namespace CharApp.Repository;

public class UnitOfWork:IUnitOfWork
{
    private ChatAppContext _chatAppContext;
    public IAttachmentRepository AttachmentRepository { get;  }
    public IMessageRepository MessageRepository { get;  }
    public IUserStatusRepository UserStatusRepository { get;  }
    public IUserChatRoomRepository UserChatRoomRepository { get;  }
    public IUserRepository UserRepository { get;  }
    public IChatRoomRepository ChatRoomRepository { get;  }

    public UnitOfWork(ChatAppContext chatAppContext)
    {
        _chatAppContext = chatAppContext;
        AttachmentRepository = new AttachmentRepository(_chatAppContext);
        MessageRepository = new MessageRepository(_chatAppContext);
        UserRepository = new UserRepository(_chatAppContext);
        UserStatusRepository = new UserStatusRepository(_chatAppContext);
        UserChatRoomRepository = new UserChatRoomRepository(_chatAppContext);
        ChatRoomRepository = new ChatRoomRepository(_chatAppContext);





    }
    
    
    
    
    
}