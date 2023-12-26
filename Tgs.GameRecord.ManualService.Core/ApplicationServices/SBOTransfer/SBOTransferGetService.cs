using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SBOTransfer;

internal class SBOTransferGetService(IMessageSender messageSender) : IGetService<SBOTransferQuery, SBOTransferResult>
{
    public async ValueTask<SBOTransferResult> GetAsync(SBOTransferQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await messageSender.RequestAsync(
            "gp.gamerecord.manual.sbotf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<SBOTransferResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
