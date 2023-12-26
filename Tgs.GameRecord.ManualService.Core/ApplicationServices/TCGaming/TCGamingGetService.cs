using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.TCGaming;

internal class TCGamingGetService(IMessageSender messageSender) : IGetService<TCGamingQuery, TCGamingResult>
{
    public async ValueTask<TCGamingResult> GetAsync(TCGamingQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await messageSender.RequestAsync(
            "gp.gamerecord.manual.tcg",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<TCGamingResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
