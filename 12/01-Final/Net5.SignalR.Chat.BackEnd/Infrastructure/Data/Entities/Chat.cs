﻿using System;
using System.Collections.Generic;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities
{
    public partial class Chat
    {
        public int ChatId { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string Type { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}