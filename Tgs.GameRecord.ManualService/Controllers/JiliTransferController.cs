using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("jilitf")]
[ApiController]
public class JiliTransferController : ControllerBase
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
    ///         {
    ///             "apiUrl":"https://uat-wb-api.jlfafafa2.com/",
    ///             "gameProviderAgentId":"PG_GPI_CNY",
    ///             "gameProviderAgentKey":"82af5971ae233eaa003b774be4079e7902ea7ff4",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        JiliTransferQueryViewModel source)
        => client
        .Jili_ScheduleFormQueuedAsync(
            gameProviderCode: "JILITF",
            name: source.GameProviderAgentId,
            subject: "gp.gamerecord.scheduleform.jilitf.queued",
            source: ScheduleFormSource.Manual,
            apiUrl: source.ApiUrl,
            agentId: source.GameProviderAgentId,
            agentKey: source.GameProviderAgentKey,
            startTime: source.StartTime,
            endTime: source.EndTime,
            cancellationToken: HttpContext.RequestAborted);
}
