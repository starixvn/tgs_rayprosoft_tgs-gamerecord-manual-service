using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("9WCRICKET")]
[ApiController]
public class WicketCricketController : ControllerBase
{
    /// <summary>
    /// Games the record by bookmaker asynchronous.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://apiinfo.cckk77.net/",
    ///             "website": "WICKETSPRO",
    ///             "cert": "wkVwQ8sMVr252EA9",
    ///             "agent": "zf055gpi",
    ///             "startTime": "2023-09-27T00:00:00+08:00",
    ///             "endTime": "2023-09-28T00:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("Bookmaker")]
    public ValueTask GameRecordByBookmakerAsync(
        [FromServices] IGameRoundsScheduleClient client,
         WicketCricketViewModel source)
        => client.WicketCricket_ScheduleFormQueuedAsync(
             gameProviderCode: "9WCRICKET",
             name: string.Concat(source.Website, "-", source.Agent),
             subject: "gp.gamerecord.scheduleform.wicketCricket.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             website: source.Website,
             cert: source.Cert,
             agent: source.Agent,
             startTime: source.StartTime,
             endTime: source.EndTime,
             reportType: "Bookmaker",
             cancellationToken: HttpContext.RequestAborted);

    /// <summary>
    /// Games the record by exchange asynchronous.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://apiinfo.cckk77.net/",
    ///             "website": "WICKETSPRO",
    ///             "cert": "wkVwQ8sMVr252EA9",
    ///             "agent": "zf055gpi",
    ///             "startTime": "2023-09-27T00:00:00+08:00",
    ///             "endTime": "2023-09-28T00:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("Exchange")]
    public ValueTask GameRecordByExchangeAsync(
        [FromServices] IGameRoundsScheduleClient client,
         WicketCricketViewModel source)
        => client.WicketCricket_ScheduleFormQueuedAsync(
             gameProviderCode: "9WCRICKET",
             name: string.Concat(source.Website, "-", source.Agent),
             subject: "gp.gamerecord.scheduleform.wicketCricket.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             website: source.Website,
             cert: source.Cert,
             agent: source.Agent,
             startTime: source.StartTime,
             endTime: source.EndTime,
             reportType: "Exchange",
             cancellationToken: HttpContext.RequestAborted);

    /// <summary>
    /// Games the record by fancy bet asynchronous.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://apiinfo.cckk77.net/",
    ///             "website": "WICKETSPRO",
    ///             "cert": "wkVwQ8sMVr252EA9",
    ///             "agent": "zf055gpi",
    ///             "startTime": "2023-09-27T00:00:00+08:00",
    ///             "endTime": "2023-09-28T00:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("FancyBet")]
    public ValueTask GameRecordByFancyBetAsync(
        [FromServices] IGameRoundsScheduleClient client,
         WicketCricketViewModel source)
        => client.WicketCricket_ScheduleFormQueuedAsync(
             gameProviderCode: "9WCRICKET",
             name: string.Concat(source.Website, "-", source.Agent),
             subject: "gp.gamerecord.scheduleform.wicketCricket.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             website: source.Website,
             cert: source.Cert,
             agent: source.Agent,
             startTime: source.StartTime,
             endTime: source.EndTime,
             reportType: "FancyBet",
             cancellationToken: HttpContext.RequestAborted);

    /// <summary>
    /// Games the record by sportsbook asynchronous.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://apiinfo.cckk77.net/",
    ///             "website": "WICKETSPRO",
    ///             "cert": "wkVwQ8sMVr252EA9",
    ///             "agent": "zf055gpi",
    ///             "startTime": "2023-09-27T00:00:00+08:00",
    ///             "endTime": "2023-09-28T00:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("Sportsbook")]
    public ValueTask GameRecordBySportsbookAsync(
        [FromServices] IGameRoundsScheduleClient client,
         WicketCricketViewModel source)
        => client.WicketCricket_ScheduleFormQueuedAsync(
             gameProviderCode: "9WCRICKET",
             name: string.Concat(source.Website, "-", source.Agent),
             subject: "gp.gamerecord.scheduleform.wicketCricket.queued",
             source: ScheduleFormSource.Manual,
             apiUrl: source.ApiUrl,
             website: source.Website,
             cert: source.Cert,
             agent: source.Agent,
             startTime: source.StartTime,
             endTime: source.EndTime,
             reportType: "Sportsbook",
             cancellationToken: HttpContext.RequestAborted);
}
