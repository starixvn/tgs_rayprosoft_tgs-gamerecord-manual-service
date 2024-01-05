using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("sabatf")]
[ApiController]
public class SabaTransferController : ControllerBase
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
    ///             "apiUrl": "http://h0i2tsa.bw6688.com/",
    ///             "operatorId": "tg",
    ///             "vendorId": "um5vspnzkx",
    ///             "startTime": "2023-08-24T18:15:00+08:00",
    ///             "endTime": "2023-08-24T19:30:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        SabaTransferQueryViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.OperatorId,
            source.VendorId,
            source.StartTime,
            source.EndTime
        };

        return messageSender.PublishAsync(
            subject: "gp.gamerecord.sabatf.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
