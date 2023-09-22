using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

namespace Notifications.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub, INotificationClient> _context;
        public MessageController(IHubContext<NotificationsHub, INotificationClient> context) 
        { 
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(string message)
        {
            await _context.Clients.All.ReceiveNotification($"Server time = {DateTime.Now} - message {message}");

            return Ok();
        }
    }
}
