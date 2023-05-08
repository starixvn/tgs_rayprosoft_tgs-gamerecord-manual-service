using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("[controller]")]
[ApiController]
public class Cards365Controller : ControllerBase
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
    ///
    ///         {
    ///             "apiUrl": "https://g5ky3i.365gaming.cc/",
    ///             "website": "card365pega001",
    ///             "cert": "40D237D0A995DFEAE0590F99552D3F6F",
    ///             "extension1": "cardp101",
    ///             "startTime": "2023-05-04T00:00:00+08:00",
    ///             "endTime": "2023-05-05T00:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
            [FromServices] IGameRoundsScheduleClient client,
            Cards365ViewModel source)
            => client.Cards365_Manual_ScheduleFormQueuedAsync(
                 gameProviderCode: "365TF",
                 name: source.Extension1,
                 subject: "gp.gamerecord.scheduleform.365tf.queued",
                 apiUrl: source.ApiUrl,
                 website: source.Website,
                 cert: source.Cert,
                 extension1: source.Extension1,
                 startTime: source.StartTime,
                 endTime: source.EndTime,
                 cancellationToken: HttpContext.RequestAborted);
}
