using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.AVIAGaming;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

internal class PragmaticPlayTransferGetService : IGetService<PragmaticPlayTransferRequest, PragmaticPlayTransferResponse>
{
    private readonly IMessageSender _messageSender;

    public PragmaticPlayTransferGetService(
        IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<PragmaticPlayTransferResponse> GetAsync(
        PragmaticPlayTransferRequest query,
        CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.pptf",
            JsonSerializer.SerializeToUtf8Bytes(query),
            cancellationToken).ConfigureAwait(false);

        return JsonSerializer.Deserialize<PragmaticPlayTransferResponse>(readOnlyMemory.Span)!;
    }
}
