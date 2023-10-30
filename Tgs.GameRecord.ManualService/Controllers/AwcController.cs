using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("AWC")]
[ApiController]
public class AwcController : ControllerBase
{
    /// <summary>
    /// Games the record asynchronous.
    /// </summary>
    /// <param name="client">The clinet.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "gameRecordApiUrl":"https://tttint.onlinegames22.com/",
    ///             "gameProviderCode":"AWC_VENUS",
    ///             "gameProviderAgentId":"cnygpivenus",
    ///             "gameProviderCert":"DfyfVhwJ8akfz2aGo3K",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
         AwcQueryViewModel source)
    {
        var parameters = new
        {
            ApiUrl = source.GameRecordApiUrl,
            AgentId = source.GameProviderAgentId,
            Cert = source.GameProviderCert,
            source.StartTime,
            source.EndTime
        };

        return client.ScheduleFormQueuedAsync(
            gameProviderCode: source.GameProviderCode,
            name: source.GameProviderAgentId,
            subject: "gp.gamerecord.scheduleform.awc.queued",
            source: ScheduleFormSource.Manual,
            parameters: JsonSerializer.Serialize(parameters),
            cancellationToken: HttpContext.RequestAborted);
    }
}
