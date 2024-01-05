using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("[controller]")]
[ApiController]
public class OBetController : ControllerBase
{
    /// <summary>
    /// Games the record asynchronous.
    /// </summary>
    /// <param name="messageSender">The message sender.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://sports-api.ob33club.com/",
    ///             "apiKey": "G4sL7r0kKFI5Mm317w99",
    ///             "agentId": "YYTES12",
    ///             "startTime": "2023-03-29T17:26:00+08:00",
    ///             "endTime": "2023-03-29T18:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        OBetViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.ApiKey,
            source.AgentId,
            source.StartTime,
            source.EndTime
        };
        return messageSender
            .PublishAsync(
            subject: "gp.gamerecord.obet.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
