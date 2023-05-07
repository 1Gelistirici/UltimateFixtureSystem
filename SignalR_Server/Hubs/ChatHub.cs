using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR_Server.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendAllMessageAsync(string message, int id, string nickName)
        {
            await Clients.Others.SendAsync("receiveMessageOther", message, id, nickName);
        }


    }
}
