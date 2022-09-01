using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Joker;

internal class JokerGetService : IGetService<JokerRequest, JokerResponse>
{
    private readonly IMessageSender _messageSender;

    public JokerGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<JokerResponse> GetAsync(JokerRequest query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.joker",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<JokerResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
