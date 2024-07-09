using Microsoft.AspNetCore.Mvc;

namespace bank_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationMessageHandler _notificationMessageHandler;

        public NotificationController(NotificationMessageHandler notificationMessageHandler)
        {
            _notificationMessageHandler = notificationMessageHandler;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] string message)
        {
            await _notificationMessageHandler.SendNotificationAsync(message);
            return Ok(new { Message = "Notification sent." });
        }
    }

}
