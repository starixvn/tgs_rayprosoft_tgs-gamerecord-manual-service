using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("PPTF")]
[ApiController]
public class PragmaticPlayTransferController : ControllerBase
{

    /// <summary>
    /// Games the record by live dealer asynchronous.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://api.prerelease-env.biz/",
    ///             "secureLogin": "tgs_tgstfw",
    ///             "secretKey": "testKey",
    ///             "startTime":"2023-04-21T11:20:00+08:00",
    ///             "endTime":"2023-04-21T11:30:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("LiveDealer")]
    public ValueTask GameRecordByLiveDealerAsync(
        [FromServices] IGameRoundsScheduleClient client,
        PragmaticPlayTransferQueryViewModel source)
        => client
        .PragmaticPlay_Manua_ScheduleFormQueuedAsync(
            gameProviderCode: "PPTF",
            name: "LC",
            subject: "gp.gamerecord.scheduleform.pptf.queued",
            apiUrl: source.ApiUrl,
            secureLogin: source.SecureLogin,
            secretKey: source.SecretKey,
            dataType: "LC",
            startTime: source.StartTime,
            endTime: source.EndTime,
            cancellationToken: HttpContext.RequestAborted);

    /// <summary>
    /// Games the record by RNG asynchronous.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://api.prerelease-env.biz/",
    ///             "secureLogin": "tgs_tgstfw",
    ///             "secretKey": "testKey",
    ///             "startTime":"2023-04-21T13:30:00+08:00",
    ///             "endTime":"2023-04-21T13:40:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("RNG")]
    public ValueTask GameRecordByRNGAsync(
        [FromServices] IGameRoundsScheduleClient client,
        PragmaticPlayTransferQueryViewModel source)
        => client
        .PragmaticPlay_Manua_ScheduleFormQueuedAsync(
            gameProviderCode: "PPTF",
            name: "RNG",
            subject: "gp.gamerecord.scheduleform.pptf.queued",
            apiUrl: source.ApiUrl,
            secureLogin: source.SecureLogin,
            secretKey: source.SecretKey,
            dataType: "RNG",
            startTime: source.StartTime,
            endTime: source.EndTime,
            cancellationToken: HttpContext.RequestAborted);

    /// <summary>
    /// Games the record by virtual sports asynchronous.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://api.prerelease-env.biz/",
    ///             "secureLogin": "tgs_tgstfw",
    ///             "secretKey": "testKey",
    ///             "startTime":"2023-04-21T11:55:00+08:00",
    ///             "endTime":"2023-04-21T12:05:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("VirtualSports")]
    public ValueTask GameRecordByVirtualSportsAsync(
        [FromServices] IGameRoundsScheduleClient client,
        PragmaticPlayTransferQueryViewModel source)
        => client
        .PragmaticPlay_Manua_ScheduleFormQueuedAsync(
            gameProviderCode: "PPTF",
            name: "VSB",
            subject: "gp.gamerecord.scheduleform.pptf.queued",
            apiUrl: source.ApiUrl,
            secureLogin: source.SecureLogin,
            secretKey: source.SecretKey,
            dataType: "VSB",
            startTime: source.StartTime,
            endTime: source.EndTime,
            cancellationToken: HttpContext.RequestAborted);
}
