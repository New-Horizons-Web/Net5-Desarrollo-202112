using Net5.SignalR.Chat.BackEnd.Infrastructure.DTO;
using System.Collections.Generic;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Repositories
{
    public interface IChatRepository
    {
        ChatDto Insert(ChatDto chat);
        List<ChatDto> ListByRoomId(int roomId);
    }
}