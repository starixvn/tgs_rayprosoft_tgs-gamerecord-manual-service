using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("wmtf")]
[ApiController]
public class WMCasinoTransferController : ControllerBase
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
    ///             "apiUrl": "https://api.a45.me/api/public/Gateway.php",
    ///             "vendorId": "hpg02twapi",
    ///             "signature": "89448b444ed2e922ddc3aa0753370238",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        WMCasinoTransferQueryViewModel source)
        => client.WMCasino_ScheduleFormQueuedAsync(
             gameProviderCode: "WMTF",
             name: source.VendorId,
             subject: "gp.gamerecord.scheduleform.wmtf.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             vendorId: source.VendorId,
             signature: source.Signature,
             startTime: source.StartTime,
             endTime: source.EndTime,
             cancellationToken: HttpContext.RequestAborted);
}
