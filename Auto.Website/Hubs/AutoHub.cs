using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Auto.WebSite.Hubs;

public class AutoHub : Hub {
    public async Task NotifyUsers(string user, string message) {
        await Clients.All.SendAsync("DisplayNotification", user, message);
    }
}