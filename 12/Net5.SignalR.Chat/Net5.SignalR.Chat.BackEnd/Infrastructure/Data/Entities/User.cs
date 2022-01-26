using System.Collections.Generic;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities
{
    public class User
    {
        public User()
        {
            Chats = new HashSet<Chat>();
            RoomUsers = new HashSet<RoomUser>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<RoomUser> RoomUsers { get; set; }

    }
}
