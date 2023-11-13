using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("CP")]
[ApiController]
public class CrPatiController : ControllerBase
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
    ///             "apiUrl": "https://apitest.fastapi2020.com/",
    ///             "apiKey": "testgpi123123",
    ///             "apiSecret": "qOV55DQYYItjW1qPArpdLNQpWY3ykFoJi4TRF86CA1A9O4pQwR",
    ///             "startTime": "2023-11-09T10:00:00+08:00",
    ///             "endTime": "2023-11-09T11:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IGameRoundsScheduleClient client,
         CrPatiViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.ApiKey,
            source.ApiSecret,
            source.StartTime,
            source.EndTime,
        };

        return client.ScheduleFormQueuedAsync(
            gameProviderCode: "CP",
            name: source.ApiKey,
            subject: "gp.gamerecord.scheduleform.cp.queued",
            source: ScheduleFormSource.Manual,
            parameters: JsonSerializer.Serialize(parameters),
            cancellationToken: HttpContext.RequestAborted);
    }
}

