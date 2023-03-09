using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("evotf")]
[ApiController]
public class EvolutionTransferController : ControllerBase
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
    ///             "apiUrl":"https://babylonpega2.uat1.evo-test.com/",
    ///             "casinoId":"babylonpega20001",
    ///             "gameHistoryApiToken":"test123",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        EvolutionTransferQueryViewModel source)
        => client.Evolution_ScheduleFormQueuedAsync(
             gameProviderCode: "EVOTF",
             name: "Configuration",
             subject: "gp.gamerecord.scheduleform.awc.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             casinoId: source.CasinoId,
             gameHistoryApiToken: source.GameHistoryApiToken,
             startTime: source.StartTime,
             endTime: source.EndTime,
             cancellationToken: HttpContext.RequestAborted);
}
