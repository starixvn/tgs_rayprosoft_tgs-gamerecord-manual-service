using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.YeeBet;

internal class YeeBetGetService : IGetService<YeeBetQuery, YeeBetResult>
{
    private readonly IMessageSender _messageSender;

    public YeeBetGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<YeeBetResult> GetAsync(YeeBetQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
        "gp.gamerecord.manual.yeebet",
        Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
        cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<YeeBetResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
