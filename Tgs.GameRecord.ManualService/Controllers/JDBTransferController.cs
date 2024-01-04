using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("jdbtf")]
[ApiController]
public class JDBTransferController : ControllerBase
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
    ///             "apiUrl": "http://api.jygrq.com",
    ///             "domain": "ZF",
    ///             "aesKey": "831057181dd07807",
    ///             "aesIV": "193a3159afebee65",
    ///             "agent": "zf055gpi",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
      [FromServices] IMessageSender messageSender,
      JDBTransferQueryViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.Domain,
            source.AesKey,
            source.AesIV,
            source.Agent,
            source.StartTime,
            source.EndTime
        };

        return messageSender.PublishAsync(
            subject: "gp.gamerecord.jdbtf.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
