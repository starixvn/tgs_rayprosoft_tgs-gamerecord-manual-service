using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("AWC")]
[ApiController]
public class AwcController : ControllerBase
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
    ///             "gameRecordApiUrl":"https://tttint.onlinegames22.com/",
    ///             "gameProviderCode":"AWC_VENUS",
    ///             "gameProviderAgentId":"cnygpivenus",
    ///             "gameProviderCert":"DfyfVhwJ8akfz2aGo3K",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] IMessageSender messageSender,
        AwcQueryViewModel source)
    {
        var parameters = new
        {
            source.GameProviderCode,
            ApiUrl = source.GameRecordApiUrl,
            AgentId = source.GameProviderAgentId,
            Cert = source.GameProviderCert,
            source.StartTime,
            source.EndTime
        };

        return messageSender.PublishAsync(
            subject: "gp.gamerecord.awc.manual",
            data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
            cancellationToken: HttpContext.RequestAborted);
    }
}
