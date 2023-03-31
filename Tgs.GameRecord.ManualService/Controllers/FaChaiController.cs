using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("FaChai")]
[ApiController]
public class FaChaiController : ControllerBase
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
    ///             "apiUrl":"http://api.fcg666.net/",
    ///             "agentCode":"GPICN",
    ///             "agentKey":"EOJC9q31Y7AnPb9i",
    ///             "currency":"CNY",
    ///             "startTime": "2023-03-13T15:45:00+08:00",
    ///             "endTime": "2023-03-13T16:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        FaChaiViewModel source)
        => client.FaChai_ScheduleFormQueuedAsync(
             gameProviderCode: "FACHAI",
             name: source.AgentCode,
             subject: "gp.gamerecord.scheduleform.fachai.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             agentCode: source.AgentCode,
             agentKey: source.AgentKey,
             currency: source.Currency,
             startTime: source.StartTime,
             endTime: source.EndTime,
             cancellationToken: HttpContext.RequestAborted);
}
