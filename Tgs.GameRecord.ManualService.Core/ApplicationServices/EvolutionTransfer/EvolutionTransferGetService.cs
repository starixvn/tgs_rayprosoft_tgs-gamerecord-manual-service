using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.EvolutionTransfer;

internal class EvolutionTransferGetService : IGetService<EvolutionTransferRequest, EvolutionTransferResponse>
{
    private readonly IMessageSender _messageSender;

    public EvolutionTransferGetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<EvolutionTransferResponse> GetAsync(EvolutionTransferRequest query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.evotf",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<EvolutionTransferResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
