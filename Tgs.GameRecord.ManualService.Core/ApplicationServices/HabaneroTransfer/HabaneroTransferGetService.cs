using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.HabaneroTransfer;

internal class HabaneroTransferGetService : IGetService<HabaneroTransferQuery, HabaneroTransferResult>
{
    private readonly IMessageSender _messageSender;

    public HabaneroTransferGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<HabaneroTransferResult> GetAsync(HabaneroTransferQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.habatf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<HabaneroTransferResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
