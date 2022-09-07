using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.AVIAGaming;

internal class AVIAGamingGetService : IGetService<AVIAGamingRequest, AVIAGamingResponse>
{
    private readonly IMessageSender _messageSender;

    public AVIAGamingGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<AVIAGamingResponse> GetAsync(AVIAGamingRequest query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.avia",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<AVIAGamingResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
