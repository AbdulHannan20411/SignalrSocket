using Microsoft.AspNetCore.SignalR;
using TaskManagement.Model;

namespace TaskManagement.SIgnalR
{
    public class SignalrHub : Hub
    {
        private static Dictionary<string, string> Users = new();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task<List<string>> GetAllUsers()
        {
            return Users.Keys.ToList();
        }

        public async Task SendMessageToUser(string userName, string message)
        {
            if (Users.TryGetValue(userName, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", userName, message);
            }
        }

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            string userName = Context.GetHttpContext()?.Request.Query["username"];

            if (!string.IsNullOrEmpty(userName))
            {
                Users[userName] = connectionId;
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string? userName = Users.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            if (userName != null)
            {
                Users.Remove(userName);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }

}
