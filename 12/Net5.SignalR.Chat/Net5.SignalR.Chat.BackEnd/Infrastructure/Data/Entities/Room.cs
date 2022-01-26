﻿using System.Collections.Generic;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities
{
    public class Room
    {
        public Room()
        {
            Chats = new HashSet<Chat>();
            RoomUsers = new HashSet<RoomUser>();
        }
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<RoomUser> RoomUsers{ get; set; }
    }
}