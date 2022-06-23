using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WMCasinoTransfer
{
    internal class WMCasinoTransferGetService : IGetService<WMCasinoTransferRequest, WMCasinoTransferResponse>
    {
        private readonly IMessageSender _messageSender;

        public WMCasinoTransferGetService(IMessageSender messageSender)
        {
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
        }

        public async ValueTask<WMCasinoTransferResponse> GetAsync(WMCasinoTransferRequest query, CancellationToken cancellationToken = default)
        {
            var readOnlyMemory = await _messageSender.RequestAsync(
                "gp.gamerecord.manual.wmtf",
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
                cancellationToken).ConfigureAwait(false);
            return JsonSerializer.Deserialize<WMCasinoTransferResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
        }
    }
}
