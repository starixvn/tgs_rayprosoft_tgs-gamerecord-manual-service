using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.GameRounds.Schedule.Client;
using Tgs.GameRounds.Schedule.Protos;
using Valhalla.MessageQueue;
using System.Threading;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route(template: "habatf")]
[ApiController]
public class HabaneroTransferController : ControllerBase
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
    ///             "apiUrl": "https://ws-test.insvr.com/",
    ///             "brandId": "b97e1834-d142-ed11-a27c-0050f23876f7",
    ///             "apiKey": "0F0B9E83-80FF-4DC7-8C8C-DF48B55DAE45",
    ///             "startTime": "2022-10-27T06:31:00+08:00",
    ///             "endTime": "2022-10-27T06:36:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        HabaneroTransferQueryViewModel source)
    {
        var parameters = new
        {
            source.ApiUrl,
            source.BrandId,
            source.ApiKey,
            source.StartTime,
            source.EndTime
        };

        return messageSender.PublishAsync(
            subject: "gp.gamerecord.habatf.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
