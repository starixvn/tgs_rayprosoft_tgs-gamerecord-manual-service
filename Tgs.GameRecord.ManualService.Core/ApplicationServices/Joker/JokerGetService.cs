using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Joker;

internal class JokerGetService : IGetService<JokerQuery, JokerResult>
{
    private readonly IMessageSender _messageSender;

    public JokerGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<JokerResult> GetAsync(JokerQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.joker",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<JokerResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
