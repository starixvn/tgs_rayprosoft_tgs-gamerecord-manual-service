using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("wmtf")]
[ApiController]
public class WMCasinoTransferController : ControllerBase
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
    ///             "apiUrl": "https://api.a45.me/api/public/Gateway.php",
    ///             "vendorId": "hpg02twapi",
    ///             "signature": "89448b444ed2e922ddc3aa0753370238",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        WMCasinoTransferQueryViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.VendorId,
            source.Signature,
            source.StartTime,
            source.EndTime
        };
        return messageSender
            .PublishAsync(
            subject: "gp.gamerecord.wmtf.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
