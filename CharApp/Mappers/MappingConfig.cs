using AutoMapper;
using CharApp.Models;

namespace CharApp.Mappers;

public class MappingConfig:Profile
{
    public MappingConfig()
    {
       CreateMap<Message, MessageDTOCreate>().ReverseMap();
       CreateMap<ChatRoom,ChatRoomDTOGet>().ReverseMap();
       CreateMap<User,UserDTOCreate>().ReverseMap();
       CreateMap<UserChatRoom,UserChatRoomDTOCreate>().ReverseMap();
       CreateMap<UserStatus,UserStatusDTOCreate>().ReverseMap();
       CreateMap<Attachment,AttachmentDTOCreate>().ReverseMap();

       CreateMap<Message,MessageDTOGet>().ReverseMap();
       CreateMap<ChatRoom,ChatRoomDTOCreate>().ReverseMap();
       CreateMap<User,UserDTOGet>().ReverseMap();
       CreateMap<UserChatRoom,UserChatRoomDTOGet>().ReverseMap();
       CreateMap<UserStatus,UserStatusDTOGet>().ReverseMap();
       CreateMap<Attachment,AttachmentDTOGet>().ReverseMap();









    }}
   
    


