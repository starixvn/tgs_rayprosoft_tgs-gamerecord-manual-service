using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.BigGamingFishing;

internal class BigGamingFishingGetService(IMessageSender messageSender) : IGetService<BigGamingFishingQuery, BigGamingFishingResult>
{
    public async ValueTask<BigGamingFishingResult> GetAsync(BigGamingFishingQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await messageSender.RequestAsync(
            "gp.gamerecord.manual.bg.fishing",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<BigGamingFishingResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
