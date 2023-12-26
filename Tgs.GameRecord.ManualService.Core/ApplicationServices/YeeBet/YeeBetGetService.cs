using System.Text;
using System.Text.Json;
using Tgs.ServiceUtility;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.YeeBet;

internal class YeeBetGetService(IMessageSender messageSender) : IGetService<YeeBetQuery, YeeBetResult>
{
    public async ValueTask<YeeBetResult> GetAsync(YeeBetQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await messageSender.RequestAsync(
        "gp.gamerecord.manual.yeebet",
        Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
        cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<YeeBetResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
