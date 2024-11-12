// See https://aka.ms/new-console-template for more information

using static System.Console;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCord;
using NetCord.Gateway;
using NetCord.Hosting.Gateway;

var builder = Host.CreateApplicationBuilder(args);
// Configure the application configuration to include the appsettings.json and appsettings.{Environment}.json files
builder.Services.AddDiscordGateway(options => {
        options.Intents = GatewayIntents.GuildMessages |
            GatewayIntents.DirectMessages |
            GatewayIntents.MessageContent |
            GatewayIntents.GuildVoiceStates;
    })
    .AddGatewayEventHandlers(typeof(Program).Assembly);

var host = builder.Build().UseGatewayEventHandlers();
await host.RunAsync();
[GatewayEvent(nameof(GatewayClient.MessageCreate))]
public class MessageCreateHandler(ILogger<MessageCreateHandler> logger) : IGatewayEventHandler<Message>
{
    public ValueTask HandleAsync(Message message) {
       // new Message("test");
        logger.LogInformation("{}", message.Content);
        return default;
    }
}