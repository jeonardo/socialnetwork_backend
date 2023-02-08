using FinalWebApp_Backend_BLL.Dto.Message;
using FinalWebApp_Backend_BLL.IdentityExtention;
using FinalWebApp_Backend_BLL.Services.Interface;
using FinalWebApp_Backend_WEB.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FinalWebApp_Backend_WEB.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MessagesController : BaseController
    {
        private IHubContext<ChatHub> _hubContext;
        private IMessageService _messageService;
        public MessagesController(IHubContext<ChatHub> hubContext, IMessageService messageService)
        {
            _hubContext = hubContext;
            _messageService = messageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var messages = await _messageService.GetMessages(id, User.GetUserId<int>());
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMessageDto dto)
        {
            var message = await _messageService.CreateMessage(dto, User.GetUserId<int>());
            return Ok(message);
        }

        [HttpPost]
        [Route("check")]
        public async Task<IActionResult> PostAndCheck(CreateMessageCheckDto dto)
        {
            await _messageService.CreateMessageAndCheck(dto, User.GetUserId<int>());
            return Ok();
        }
    }
}