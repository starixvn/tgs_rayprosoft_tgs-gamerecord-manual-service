using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("GKX")]
[ApiController]
public class GKXGamingController : ControllerBase
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
    ///             "apiRecordUrl": "https://wc-record.orz16.com/",
    ///             "deskey": "03CFE0179704BCDF",
    ///             "md5key": "337B01054C6FA208",
    ///             "agentId": "60073",
    ///             "startTime": "2023-07-26T11:50:00+08:00",
    ///             "endTime": "2023-07-26T12:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        GKXGamingViewModel source)
    {
        var data = new
        {
            ApiUrl = source.ApiRecordUrl,
            source.Deskey,
            source.Md5key,
            source.AgentId,
            source.StartTime,
            source.EndTime
        };
        return messageSender
            .PublishAsync(
            subject: "gp.gamerecord.gkx.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
