using System;
using System.Collections.Generic;
using System.Text;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.DTO
{
    public class RoomUserDto
    {
        public int RoomUserId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}
