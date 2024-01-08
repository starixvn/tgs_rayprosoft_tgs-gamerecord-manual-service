using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("[controller]")]
[ApiController]
public class YeeBetController : ControllerBase
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
    ///             "apiUrl": "http://api.98kbus.top/",
    ///             "appId": "xtdA15OTVGEP",
    ///             "secretKey": "4885366DF30D880224FF6AA46FBDE4F0",
    ///             "startTime": "2023-04-10T10:00:00+08:00",
    ///             "endTime": "2023-04-10T11:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        YeeBetViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.AppId,
            source.SecretKey,
            source.StartTime,
            source.EndTime
        };
        return messageSender
            .PublishAsync(
            subject: "gp.gamerecord.yeebet.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
