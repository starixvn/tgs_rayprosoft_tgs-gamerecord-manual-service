using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGViaGaming;

internal class WGViaGamingGetService : IGetService<WGViaGamingQuery, WGViaGamingResult>
{
    private readonly IMessageSender _messageSender;

    public WGViaGamingGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<WGViaGamingResult> GetAsync(WGViaGamingQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.wgvia",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<WGViaGamingResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
