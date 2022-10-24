using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.VRGaming;

internal class VRGamingGetService : IGetService<VRGamingQuery, VRGamingResult>
{
    private readonly IMessageSender _messageSender;

    public VRGamingGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<VRGamingResult> GetAsync(VRGamingQuery query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.vr",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<VRGamingResult>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
