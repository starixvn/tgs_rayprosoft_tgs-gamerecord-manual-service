using System.Text;
using System.Text.Json;
using Tgs.MessageQueue;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SM01;

internal class SM01GetService : IGetService<SM01Query, SM01Result>
{
    private readonly IMessageSender _messageSender;

    public SM01GetService(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    public async ValueTask<SM01Result> GetAsync(SM01Query query, CancellationToken cancellationToken = default)
    {
        var readOnlyMemory = await _messageSender.RequestAsync(
            "gp.gamerecord.manual.sm01",
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(query)),
            cancellationToken).ConfigureAwait(false);
        return JsonSerializer.Deserialize<SM01Result>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
    }
}
