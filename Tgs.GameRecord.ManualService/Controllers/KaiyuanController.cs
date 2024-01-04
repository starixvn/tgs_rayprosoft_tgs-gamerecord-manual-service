using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("KY")]
[ApiController]
public class KaiyuanController : ControllerBase
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
    ///             "apiRecordUrl": "https://record.szj5888.com/",
    ///             "deskey": "8AB567D20F43101C",
    ///             "md5key": "92A194FF62CD8078",
    ///             "agentId": "602949",
    ///             "startTime": "2023-07-19T15:50:00+08:00",
    ///             "endTime": "2023-07-19T16:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        KaiyuanViewModel source)
    {
        var parameters = new
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
            subject: "gp.gamerecord.ky.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
