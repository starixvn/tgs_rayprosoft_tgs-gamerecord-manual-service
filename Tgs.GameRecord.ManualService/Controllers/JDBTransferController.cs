using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("jdbtf")]
[ApiController]
public class JDBTransferController : ControllerBase
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
    ///             "apiUrl": "http://api.jygrq.com",
    ///             "domain": "ZF",
    ///             "aesKey": "831057181dd07807",
    ///             "aesIV": "193a3159afebee65",
    ///             "agent": "zf055gpi",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        JDBTransferQueryViewModel source)
        => client.JDB_ScheduleFormQueuedAsync(
             gameProviderCode: "JDBTF",
             name: source.Agent,
             subject: "gp.gamerecord.scheduleform.jdbtf.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             domain: source.Domain,
             aesKey: source.AesKey,
             aesIV: source.AesIV,
             agent: source.Agent,
             startTime: source.StartTime,
             endTime: source.EndTime,
             cancellationToken: HttpContext.RequestAborted);
}
