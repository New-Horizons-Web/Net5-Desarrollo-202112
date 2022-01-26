using Net5.SignalR.Chat.BackEnd.Infrastructure.DTO;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Repositories
{
    public interface IRoomUserRepository
    {
        RoomUserDto GetByRoomIdAndUserId(int roomId, int userId);
        RoomUserDto Insert(RoomUserDto roomUser);
        RoomUserDto Update(RoomUserDto roomUser);
    }
}