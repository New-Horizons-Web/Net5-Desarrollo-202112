using Net5.SignalR.Chat.BackEnd.Infrastructure.DTO;
using System.Collections.Generic;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Repositories
{
    public interface IRoomRepository
    {
        RoomDto GetByRoomId(int roomId);
        RoomDto GetByRoomName(string roomName);
        RoomDto Insert(RoomDto room);
        List<RoomDto> ListRooms();
    }
}