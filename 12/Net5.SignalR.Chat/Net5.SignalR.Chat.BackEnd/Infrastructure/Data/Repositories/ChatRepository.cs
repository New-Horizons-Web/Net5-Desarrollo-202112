using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Contexts;
using Net5.SignalR.Chat.BackEnd.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly SignalRChatContext _context;
        public ChatRepository(SignalRChatContext context)
        {
            _context = context;
        }
        public List<ChatDto> ListByRoomId(int roomId)
        {
            var query = from c in _context.Chats
                        where c.RoomId == roomId
                        select new ChatDto
                        {
                            ChatId = c.ChatId,
                            Date = c.Date,
                            Message = c.Message,
                            RoomId = c.RoomId,
                            UserId = c.UserId,
                            Type = c.Type
                        };
            List<ChatDto> chats = query.ToList();

            return chats;
        }

        public ChatDto Insert(ChatDto chat)
        {
            Entities.Chat newChat = new Entities.Chat
            {
                Date = chat.Date,
                Message = chat.Message,
                RoomId = chat.RoomId,
                UserId = chat.UserId,
                Type = chat.Type
            };

            _context.Chats.Add(newChat);
            _context.SaveChanges();

            chat.ChatId = newChat.ChatId;
            return chat;
        }
    }
}
