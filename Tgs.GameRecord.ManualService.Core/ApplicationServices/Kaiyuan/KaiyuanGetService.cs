using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Kaiyuan;

internal class KaiyuanGetService : IGetService<KaiyuanQuery, KaiyuanResult>
{
    private readonly IMessageSender _messageSender;

    public KaiyuanGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<KaiyuanResult> GetAsync(KaiyuanQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.ky",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<KaiyuanResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
