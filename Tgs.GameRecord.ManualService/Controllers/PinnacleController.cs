using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("[controller]")]
[ApiController]
public class PinnacleController : ControllerBase
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
    ///             "apiUrl": "https://paapistg.oreo88.com",
    ///             "agentCode": "V0201",
    ///             "agentKey": "8d0e9ac0-99d8-48c7-8307-bc328c4181f6",
    ///             "secretKey": "zenDIdY7Knuzmeen",
    ///             "startTime": "2023-05-23T19:25:00+08:00",
    ///             "endTime": "2023-05-23T19:30:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
            [FromServices] IGameRoundsScheduleClient client,
            PinnacleViewModel source)
            => client.Pinnacle_ScheduleFormQueuedAsync(
                 gameProviderCode: "PINNACLE",
                 name: source.AgentCode,
                 subject: "gp.gamerecord.scheduleform.pinnacle.queued",
                 source: ScheduleFormSource.Manual,
                 apiUrl: source.ApiUrl,
                 agentCode: source.AgentCode,
                 agentKey: source.AgentKey,
                 secretKey: source.SecretKey,
                 startTime: source.StartTime,
                 endTime: source.EndTime,
                 cancellationToken: HttpContext.RequestAborted);
}
