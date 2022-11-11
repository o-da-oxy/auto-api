using Auto.Messages;
using EasyNetQ;
using Microsoft.Extensions.Configuration;

class Program
{
    private static readonly IConfigurationRoot config = ReadConfiguration();
    private const string SUBSCRIBER_ID = "Auto.AuditLog";

    private static IConfigurationRoot ReadConfiguration()
    {
        var basePath = Directory.GetParent(AppContext.BaseDirectory).FullName;
        return new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }

    static async Task Main(string[] args)
    {
        using var bus = RabbitHutch.CreateBus(config.GetConnectionString("AutoRabbitMQ")!);
        Console.WriteLine("Connected! Listening for NewOwnerMessage messages.");
        await bus.PubSub.SubscribeAsync<NewOwnerMessage>(SUBSCRIBER_ID, HandleNewOwnerMessage);
        Console.ReadKey(true);
    }

    private static void HandleNewOwnerMessage(NewOwnerMessage message)
    {
        var csv =
            $"{message.FirstName}, {message.LastName}, {message.PhoneNumber}, {message.TimeNow:O}";
        Console.WriteLine(csv);
    }
}

