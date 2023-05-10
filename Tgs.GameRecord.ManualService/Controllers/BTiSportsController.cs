using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("bti")]
[ApiController]
public class BTiSportsController : ControllerBase
{
    /// <summary>
    /// Games the record asynchronous.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///
    ///         {
    ///             "tokenApiUrl": "https://asia-east2-bq-data-api.cloudfunctions.net/",
    ///             "openBetsApiUrl": "https://get-open-bets-d5nlg5buca-de.a.run.app/",
    ///             "historyBetsPagingApiUrl": "https://get-history-bets-paging-d5nlg5buca-de.a.run.app/",
    ///             "agentUserName": "PegaGaming_GPIRMB",
    ///             "agentPassword": "IM60Ho7Y4B9C",
    ///             "startTime": "2022-10-24T00:00:00+08:00",
    ///             "endTime": "2022-10-25T00:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        BTiSportsQueryViewModel source)
        => client.BTi_ScheduleFormQueuedAsync(
            gameProviderCode: "BTI",
            name: source.AgentUserName,
            subject: "gp.gamerecord.scheduleform.bti.queued",
            source: ScheduleFormSource.Manual,
            tokenApiUrl: source.TokenApiUrl,
            openBetsApiUrl: source.OpenBetsApiUrl,
            historyBetsPagingApiUrl: source.HistoryBetsPagingApiUrl,
            agentUserName: source.AgentUserName,
            agentPassword: source.AgentPassword,
            startTime: source.StartTime,
            endTime: source.EndTime,
            cancellationToken: HttpContext.RequestAborted);
}
