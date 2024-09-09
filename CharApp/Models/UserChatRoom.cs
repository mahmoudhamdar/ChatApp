namespace CharApp.Models;
public class UserChatRoom
{
    public UserChatRoom()
    {
        UserChatRoomId = Guid.NewGuid().ToString();
    }
    public string UserChatRoomId { get; set; } 
    public string UserId { get; set; }
    public User User { get; set; }
    public string RoomId { get; set; }
    public ChatRoom ChatRoom { get; set; }
}
