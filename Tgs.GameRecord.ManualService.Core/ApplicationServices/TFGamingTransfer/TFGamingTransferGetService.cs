using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.TFGamingTransfer;

internal class TFGamingTransferGetService(IMessageSender messageSender) : IGetService<TFGamingTransferQuery, TFGamingTransferResult>
{
    public async ValueTask<TFGamingTransferResult> GetAsync(TFGamingTransferQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await messageSender.RequestAsync(
            "gp.gamerecord.manual.tftf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<TFGamingTransferResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
