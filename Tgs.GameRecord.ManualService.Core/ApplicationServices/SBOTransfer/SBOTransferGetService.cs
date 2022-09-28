using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SBOTransfer;

internal class SBOTransferGetService : IGetService<SBOTransferRequest, SBOTransferResponse>
{
    private readonly IMessageSender _messageSender;

    public SBOTransferGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<SBOTransferResponse> GetAsync(SBOTransferRequest query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.sbotf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<SBOTransferResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
