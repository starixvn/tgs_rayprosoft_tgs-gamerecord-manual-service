using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.TCGaming;

internal class TCGamingGetService : IGetService<TCGamingRequest, TCGamingResponse>
{
    private readonly IMessageSender _messageSender;

    public TCGamingGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<TCGamingResponse> GetAsync(TCGamingRequest query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.tcg",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<TCGamingResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
