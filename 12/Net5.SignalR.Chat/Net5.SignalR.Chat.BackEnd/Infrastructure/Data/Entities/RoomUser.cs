namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities
{
    public class RoomUser
    {
        public int RoomUserId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}