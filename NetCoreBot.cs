using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

public class NetCoreBot : IBot
{
    ILogger _logger;

    public NetCoreBot(ILoggerFactory loggerFactory)
    {
        if (loggerFactory == null)
        {
            throw new System.ArgumentNullException(nameof(loggerFactory));
        }

        _logger = loggerFactory.CreateLogger<NetCoreBot>();
        _logger.LogTrace("EchoBot turn start.");
        // _accessors = accessors ?? throw new System.ArgumentNullException(nameof(accessors));
    }

    public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
    {
        switch (turnContext.Activity.Type)
        {
            case ActivityTypes.Message:
                await HandleMessage(turnContext);
                break;
            default:
                await turnContext.SendActivityAsync($"{turnContext.Activity.Type} event detected");
                break;
        }
    }

    private async Task HandleMessage(ITurnContext context)
    {
        var message = context.Activity.Text;
        await context.SendActivityAsync("Hi there");
        await context.SendActivityAsync($"You typed: {message}");
    }
}