using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("swtf")]
[ApiController]
public class SkywindTransferController : ControllerBase
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
    ///             "apiUrl": "https://api.gcpstg.m27613.com/",
    ///             "secretKey": "66a44892-54dc-488b-b755-1d1da4f8ad61",
    ///             "username": "PGT_brand_api_stg",
    ///             "password": "ArSg5e6CR2g1wIgB",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///          }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        SkywindTransferQueryViewModel source)
        => client.Skywind_ScheduleFormQueuedAsync(
             gameProviderCode: "SWTF",
             name: "Configuration",
             subject: "gp.gamerecord.scheduleform.swtf.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             secretKey: source.SecretKey,
             username: source.Username,
             password: source.Password,
             startTime: source.StartTime,
             endTime: source.EndTime,
             cancellationToken: HttpContext.RequestAborted);
}
