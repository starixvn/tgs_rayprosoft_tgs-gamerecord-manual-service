using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.LEGaming;

internal class LEGamingGetService : IGetService<LEGamingQuery, LEGamingResult>
{
    private readonly IMessageSender _messageSender;

    public LEGamingGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<LEGamingResult> GetAsync(LEGamingQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.ly",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<LEGamingResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
