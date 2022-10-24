using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.JDBTransfer;

internal class JDBTransferGetService : IGetService<JDBTransferQuery, JDBTransferResult>
{
    private readonly IMessageSender _messageSender;

    public JDBTransferGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<JDBTransferResult> GetAsync(JDBTransferQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.jdbtf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<JDBTransferResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
