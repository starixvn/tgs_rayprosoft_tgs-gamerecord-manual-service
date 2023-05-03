using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("im_esp")]
[ApiController]
public class IMESportsController : ControllerBase
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
    ///             "reportUrl":"http://operatorapi-report.staging.imaegisapi.com/",
    ///             "merchantCode":"OfL5H2hKOIP9tHp9ZIoqYeggJtFC39zQ",
    ///             "merchantPrefix":"IM1S3",
    ///             "startTime": "2023-04-27T13:00:00+08:00",
    ///             "endTime": "2023-04-27T14:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        InplayMatrixESportsViewModel source)
        => client
        .InplayMatrix_ScheduleFormQueuedAsync(
            gameProviderCode: "IM_ESP",
            name: source.MerchantPrefix,
            subject: "gp.gamerecord.scheduleform.im.esp.queued",
            source: ScheduleFormSource.Manual,
            apiUrl: source.ReportUrl,
            merchantCode: source.MerchantCode,
            merchantPrefix: source.MerchantPrefix,
            startTime: source.StartTime,
            endTime: source.EndTime,
            cancellationToken: HttpContext.RequestAborted);
}
