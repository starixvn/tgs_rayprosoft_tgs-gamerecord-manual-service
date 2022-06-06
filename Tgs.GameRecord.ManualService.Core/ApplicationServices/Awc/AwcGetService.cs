using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Awc
{
    internal class AwcGetService : IGetService<AwcRequest, AwcResponse>
    {
        private readonly IMessageSender _messageSender;

        public AwcGetService(IMessageSender messageSender)
        {
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
        }

        public async ValueTask<AwcResponse> GetAsync(AwcRequest query, CancellationToken cancellationToken = default)
        {
            var readOnlyMemory = await _messageSender.RequestAsync(
                "gp.gamerecord.manual.awc",
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
                cancellationToken).ConfigureAwait(false);
            return JsonSerializer.Deserialize<AwcResponse>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
        }
    }
}
