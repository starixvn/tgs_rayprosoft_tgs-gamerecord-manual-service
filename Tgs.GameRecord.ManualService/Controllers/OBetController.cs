using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("[controller]")]
[ApiController]
public class OBetController : ControllerBase
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
    ///             "apiUrl": "https://sports-api.ob33club.com/",
    ///             "apiKey": "G4sL7r0kKFI5Mm317w99",
    ///             "agentId": "YYTES12",
    ///             "startDate": "2023-03-29T17:26:00+08:00",
    ///             "endDate": "2023-03-29T18:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
            [FromServices] IGameRoundsScheduleClient client,
            OBetViewModel source)
            => client.OBet_ScheduleFormQueuedAsync(
                 gameProviderCode: "FACHAI",
                 name: source.AgentId,
                 subject: "gp.gamerecord.scheduleform.obet.queued",
                 source: ScheduleFormSource.Manual,
                 apiUrl: source.ApiUrl,
                 apiKey: source.ApiKey,
                 agentId: source.AgentId,
                 startTime: source.StartTime,
                 endTime: source.EndTime,
                 cancellationToken: HttpContext.RequestAborted);
}
