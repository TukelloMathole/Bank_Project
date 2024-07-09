using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketManager;

public class NotificationMessageHandler : WebSocketHandler
{
    public NotificationMessageHandler(WebSocketConnectionManager webSocketConnectionManager)
        : base(webSocketConnectionManager)
    {
    }

    public async Task SendNotificationAsync(string message)
    {
        var allSockets = WebSocketConnectionManager.GetAll();
        foreach (var socket in allSockets)
        {
            if (socket.Value.State == WebSocketState.Open)
            {
                await SendMessageAsync(socket.Value, message);
            }
        }
    }

    private async Task SendMessageAsync(WebSocket socket, string message)
    {
        var messageBuffer = Encoding.UTF8.GetBytes(message);
        var segment = new ArraySegment<byte>(messageBuffer);
        await socket.SendAsync(segment, WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);
    }
}
