using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SabaTransfer;

internal class SabaTransferGetService : IGetService<SabaTransferQuery, SabaTransferResult>
{
    private readonly IMessageSender _messageSender;

    public SabaTransferGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<SabaTransferResult> GetAsync(SabaTransferQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.sabatf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<SabaTransferResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
