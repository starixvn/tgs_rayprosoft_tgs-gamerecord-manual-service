using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

internal class PragmaticPlayTransferGetService : IGetService<PragmaticPlayTransferQuery, PragmaticPlayTransferResult>
{
    private readonly IMessageSender _messageSender;

    public PragmaticPlayTransferGetService(
        IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<PragmaticPlayTransferResult> GetAsync(
        PragmaticPlayTransferQuery query,
        CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.pptf",
            JsonSerializer.SerializeToUtf8Bytes(query),
            cancellationToken).ConfigureAwait(false);

        return JsonSerializer.Deserialize<PragmaticPlayTransferResult>(readOnlyMemory.Span)!;
    }
}
