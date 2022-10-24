using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.BTiSports;

internal class BTiSportsGetService : IGetService<BTiSportsQuery, BTiSportsResult>
{
    private readonly IMessageSender _messageSender;

    public BTiSportsGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<BTiSportsResult> GetAsync(BTiSportsQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.bti",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<BTiSportsResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
