using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.JiliTransfer;

internal class JiliTransferGetService : IGetService<JiliTransferQuery, JiliTransferResult>
{
    private readonly IMessageSender _messageSender;

    public JiliTransferGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<JiliTransferResult> GetAsync(JiliTransferQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.jilitf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<JiliTransferResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
