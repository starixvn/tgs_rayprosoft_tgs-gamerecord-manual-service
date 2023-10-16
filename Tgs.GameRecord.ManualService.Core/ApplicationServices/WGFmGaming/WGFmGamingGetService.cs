using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGFmGaming;

internal class WGFmGamingGetService : IGetService<WGFmGamingQuery, WGFmGamingResult>
{
    private readonly IMessageSender _messageSender;

    public WGFmGamingGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<WGFmGamingResult> GetAsync(WGFmGamingQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.wgfm",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<WGFmGamingResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
