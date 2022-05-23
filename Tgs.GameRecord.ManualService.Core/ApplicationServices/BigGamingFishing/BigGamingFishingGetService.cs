using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.BigGamingFishing
{
    internal class BigGamingFishingGetService : IGetService<BigGamingFishingRequest, BigGamingFishingResponse>
    {
        private readonly IMessageSender _messageSender;

        public BigGamingFishingGetService(IMessageSender messageSender)
        {
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
        }

        public async ValueTask<BigGamingFishingResponse> GetAsync(BigGamingFishingRequest query, CancellationToken cancellationToken = default)
        {
            var readOnlyMemory = await _messageSender.RequestAsync(
                "gp.gamerecord.manual.bg.fishing",
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
                cancellationToken).ConfigureAwait(false);
            return JsonSerializer.Deserialize<BigGamingFishingResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
        }
    }
}
