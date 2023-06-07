using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("Joker")]
[ApiController]
public class JokerController : ControllerBase
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
    ///             "apiUrl": "https://w.api788.net/",
    ///             "appId": "THDT",
    ///             "secretKey": "s5gawreoto5e1",
    ///             "startTime": "2023-05-29T14:50:00+08:00",
    ///             "endTime": "2023-05-29T15:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
        JokerQueryViewModel source)
        => client
        .Joker_ScheduleFormQueuedAsync(
            gameProviderCode: "JOKER",
            name: source.AppId,
            subject: "gp.gamerecord.scheduleform.joker.queued",
            source: ScheduleFormSource.Manual,
            apiUrl: source.ApiUrl,
            appId: source.AppId,
            secretKey: source.SecretKey,
            startTime: source.StartTime,
            endTime: source.EndTime,
            cancellationToken: HttpContext.RequestAborted);
}
