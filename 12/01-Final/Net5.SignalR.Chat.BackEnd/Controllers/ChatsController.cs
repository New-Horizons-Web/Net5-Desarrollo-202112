using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Net5.SignalR.Chat.BackEnd.Application;
using Net5.SignalR.Chat.BackEnd.Infrastructure.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Net5.SignalR.Chat.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatApplicationService _chatApplicationService;
        
        public ChatsController(IChatApplicationService chatApplicationService)
        {
            _chatApplicationService = chatApplicationService;            
        }

        [HttpGet()]
        public List<ChatDto> List([FromQuery(Name = "roomId")] int roomId)
        {
            return _chatApplicationService.ListChatByRoomId(roomId);
        }

        [HttpPost]
        public ChatDto Post([FromBody] ChatDto chat)
        {
            chat = _chatApplicationService.InsertChat(chat);
            return chat;
        }       
    }
}
