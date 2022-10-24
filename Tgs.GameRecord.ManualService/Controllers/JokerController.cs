using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.Joker;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("Joker")]
[ApiController]
public class JokerController : ControllerBase
{
    /// <summary>
    /// Games the record asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br/>
    ///
    ///     Post
    ///         {
    ///             "brandCode": "Default",
    ///             "agentId": "TGVY",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<JokerResultViewModel> GameRecordAsync(
        [FromServices] IGetService<JokerQuery, JokerResult> service,
        JokerQueryViewModel source)
    {
        var result = await service.GetAsync(new JokerQuery()
        {
            BrandCode = source.BrandCode,
            AgentId = source.AgentId,
            StartTime = source.StartTime,
            EndTime = source.EndTime
        }).ConfigureAwait(false);

        return new JokerResultViewModel()
        {
            Success = result.Success,
            LastGameRecordTime = result.LastGameRecordTime,
            SuccessCount = result.SuccessCount,
            FailureCount = result.FailureCount,
            Count = result.Count,
        };
    }
}
