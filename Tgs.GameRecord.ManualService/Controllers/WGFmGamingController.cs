using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("WGFM")]
[ApiController]
public class WGFmGamingController : ControllerBase
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
    ///             "apiUrl": "https://api.jsc080.net/",
    ///             "partnerCode": "TA",
    ///             "partnerKey": "abc1238888888888",
    ///             "partnerIV": "cba1238888888888",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        WGFmGamingQueryViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.PartnerCode,
            source.PartnerKey,
            source.PartnerIV,
            source.StartTime,
            source.EndTime
        };

        return messageSender.PublishAsync(
            subject: "gp.gamerecord.wgfm.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
