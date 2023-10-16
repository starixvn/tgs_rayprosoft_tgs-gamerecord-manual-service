using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Endorphina;

internal class EndorphinaGetService : IGetService<EndorphinaQuery, EndorphinaResult>
{
    private readonly IMessageSender _messageSender;

    public EndorphinaGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<EndorphinaResult> GetAsync(EndorphinaQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
        "gp.gamerecord.manual.endor",
        Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
        cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<EndorphinaResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
