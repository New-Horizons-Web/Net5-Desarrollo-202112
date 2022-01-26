using Microsoft.AspNetCore.SignalR;
using Net5.SignalR.Chat.BackEnd.Infrastructure.DTO;
using System.Threading.Tasks;

namespace Net5.SignalR.Chat.BackEnd.Hubs
{
    public class ChatHub:Hub
    {
        public async Task ListRoomsServer()
        {
            await Clients.All.SendAsync("ListRoomsClient");
        }
        public async Task SendChatServer(ChatDto chat)
        {
            await Clients.All.SendAsync("ReciveChatClient",chat);
        }
        public async Task ListUsersByRoomIdServer(int roomId)
        {
            await Clients.All.SendAsync("ListUsersByRoomIdClient", roomId);
        }
    }
}
