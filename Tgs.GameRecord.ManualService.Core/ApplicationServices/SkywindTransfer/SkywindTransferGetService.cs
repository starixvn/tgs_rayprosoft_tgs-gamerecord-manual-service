using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SkywindTransfer;

internal class SkywindTransferGetService : IGetService<SkywindTransferRequest, SkywindTransferResponse>
{
    private readonly IMessageSender _messageSender;

    public SkywindTransferGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<SkywindTransferResponse> GetAsync(SkywindTransferRequest query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.swtf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<SkywindTransferResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
