using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("PPTF")]
[ApiController]
public class PragmaticPlayTransferController : ControllerBase
{
    /// <summary>
    /// Games the record by live dealer asynchronous.
    /// </summary>
    /// <param name="messageSender">The message sender.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://api.prerelease-env.biz/",
    ///             "secureLogin": "tgs_tgstfw",
    ///             "secretKey": "testKey",
    ///             "startTime":"2023-04-21T11:20:00+08:00",
    ///             "endTime":"2023-04-21T11:30:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("LiveDealer")]
    public ValueTask GameRecordByLiveDealerAsync(
        [FromServices] IMessageSender messageSender,
        PragmaticPlayTransferQueryViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.SecureLogin,
            source.SecretKey,
            DataType = "LC",
            source.StartTime,
            source.EndTime
        };

        return messageSender.PublishAsync(
            subject: "gp.gamerecord.pptf.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }

    /// <summary>
    /// Games the record by RNG asynchronous.
    /// </summary>
    /// <param name="messageSender">The message sender.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://api.prerelease-env.biz/",
    ///             "secureLogin": "tgs_tgstfw",
    ///             "secretKey": "testKey",
    ///             "startTime":"2023-04-21T13:30:00+08:00",
    ///             "endTime":"2023-04-21T13:40:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("RNG")]
    public ValueTask GameRecordByRNGAsync(
        [FromServices] IMessageSender messageSender,
        PragmaticPlayTransferQueryViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.SecureLogin,
            source.SecretKey,
            DataType = "RNG",
            source.StartTime,
            source.EndTime
        };

        return messageSender.PublishAsync(
            subject: "gp.gamerecord.pptf.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }

    /// <summary>
    /// Games the record by virtual sports asynchronous.
    /// </summary>
    /// <param name="messageSender">The message sender.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiUrl": "https://api.prerelease-env.biz/",
    ///             "secureLogin": "tgs_tgstfw",
    ///             "secretKey": "testKey",
    ///             "startTime":"2023-04-21T11:55:00+08:00",
    ///             "endTime":"2023-04-21T12:05:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("VirtualSports")]
    public ValueTask GameRecordByVirtualSportsAsync(
        [FromServices] IMessageSender messageSender,
        PragmaticPlayTransferQueryViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.SecureLogin,
            source.SecretKey,
            DataType = "VSB",
            source.StartTime,
            source.EndTime
        };

        return messageSender.PublishAsync(
            subject: "gp.gamerecord.pptf.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
