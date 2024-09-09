


using CharApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    namespace CharApp.Data;
public class ChatAppContext :  IdentityDbContext<User>
{
    public new DbSet<User> Users { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<UserChatRoom> UserChatRooms { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<UserStatus> UserStatuses { get; set; }

    public ChatAppContext(DbContextOptions<ChatAppContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<IdentityRole> roles = new List<IdentityRole>
        {

            new IdentityRole
            {
               
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                
                Name = "User",
                NormalizedName = "USER"
            }
            
            
        };
        
        modelBuilder.Entity<IdentityRole>().HasData(roles);
        
        //Users
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserStatus)
            .WithOne(u => u.User);
        modelBuilder.Entity<User>()
            .HasMany(u => u.Messages)
            .WithOne(u => u.User);
        modelBuilder.Entity<User>()
            .HasMany(u=>u.UserChatRooms)
            .WithOne(u=>u.User);
        //UsersStatuses
        modelBuilder.Entity<UserStatus>()
            .HasKey(us => us.UserId);
        modelBuilder.Entity<UserStatus>()
            .HasOne(us=>us.User)
            .WithOne(us=>us.UserStatus)
            .HasForeignKey<UserStatus>(p => p.UserId);
        //Messages
        modelBuilder.Entity<Message>()
            .HasKey(m => m.MessageId);
        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(m=>m.Messages)
            .HasForeignKey(m=>m.UserId);
        modelBuilder.Entity<Message>()
            .HasOne(m => m.ChatRoom)
            .WithMany(m => m.Messages)
            .HasForeignKey(m => m.RoomId);
        //ChatRoom    
        modelBuilder.Entity<ChatRoom>()
            .HasKey(cr => cr.RoomId);
        modelBuilder.Entity<ChatRoom>()
            .HasMany(cr => cr.UserChatRooms)
            .WithOne(cr => cr.ChatRoom)
            .HasForeignKey(cr=>cr.UserChatRoomId);
        //UserChatRooms
        modelBuilder.Entity<UserChatRoom>()
            .HasKey(ucr => ucr.UserChatRoomId);
        modelBuilder.Entity<UserChatRoom>()
            .HasOne(ucr => ucr.User)
            .WithMany(ucr => ucr.UserChatRooms)
            .HasForeignKey(ucr=>ucr.UserId);
        modelBuilder.Entity<UserChatRoom>()
            .HasOne(ucr => ucr.ChatRoom)
            .WithMany(ucr => ucr.UserChatRooms)
            .HasForeignKey(ucr => ucr.RoomId);
        //Attachments
        modelBuilder.Entity<Attachment>()
            .HasKey(a => a.AttachmentId);
        modelBuilder.Entity<Attachment>()
            .HasOne(a => a.Message)
            .WithMany(a => a.Attachments)
            .HasForeignKey(a=>a.MessageId);
            






    }
}

