using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("AVIA")]
[ApiController]
public class AVIAGamingController : ControllerBase
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
    ///
    ///         {
    ///             "apiUrl": "https://api.ksdj004.com/",
    ///             "authorization": "81e2d1a24c684a76a710a70f4900a353",
    ///             "startTime": "2023-07-21T07:00:00+00:00",
    ///             "endTime": "2023-07-21T09:00:00+00:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
         AVIAGamingViewModel source)
    {
        var data = new
        {
            source.ApiUrl,
            source.Authorization,
            source.StartTime,
            source.EndTime
        };
        return messageSender
            .PublishAsync(
            subject: "gp.gamerecord.manual.avia",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
