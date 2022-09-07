using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGViaGaming;

internal class WGViaGamingGetService : IGetService<WGViaGamingRequest, WGViaGamingResponse>
{
    private readonly IMessageSender _messageSender;

    public WGViaGamingGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<WGViaGamingResponse> GetAsync(WGViaGamingRequest query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.wgvia",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<WGViaGamingResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
