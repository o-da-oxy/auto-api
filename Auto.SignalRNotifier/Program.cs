using Auto.Data.Entities;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace SignalRNotifier;

public static class Program
{
    private const string SIGNALR_HUB_URL = "http://localhost:5000/hub";
    private static HubConnection hub;

    public static async Task Main(string[] args)
    {
        hub = new HubConnectionBuilder().WithUrl(SIGNALR_HUB_URL).Build();
        await hub.StartAsync();
        Console.WriteLine("Hub started!");
        Console.WriteLine("Press any key to send a message");
        while (true)
        {
            var input = Console.ReadLine();
            var message = JsonConvert.SerializeObject(new Owner
            {
                FirstName = "First Name",
                LastName = "Last Name",
                PhoneNumber = "Phone Number",
                Registration = "Registration"
            });
            await hub.SendAsync("NotifyUsers", "Auto.Notifier", message);
            Console.WriteLine($"Message: {message}");
        }
    }
}