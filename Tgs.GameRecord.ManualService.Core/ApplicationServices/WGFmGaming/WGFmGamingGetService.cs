using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGFmGaming;

internal class WGFmGamingGetService(IMessageSender messageSender) : IGetService<WGFmGamingQuery, WGFmGamingResult>
{
    public async ValueTask<WGFmGamingResult> GetAsync(WGFmGamingQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await messageSender.RequestAsync(
            "gp.gamerecord.manual.wgfm",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<WGFmGamingResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
