using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.WGViaGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("WGVIA")]
[ApiController]
public class WGViaGamingController : ControllerBase
{
    /// <summary>
    /// Games the record asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<WGViaGamingResultViewModel> GameRecordAsync(
        [FromServices] IGetService<WGViaGamingQuery, WGViaGamingResult> service,
         WGViaGamingQueryViewModel source)
    {
        var result = await service.GetAsync(new WGViaGamingQuery()
        {
            StartTime = source.StartTime,
            EndTime = source.EndTime
        }).ConfigureAwait(false);

        return new WGViaGamingResultViewModel()
        {
            Success = result.Success,
            LastGameRecordTime = result.LastGameRecordTime,
            SuccessCount = result.SuccessCount,
            FailureCount = result.FailureCount,
            Count = result.Count,
        };
    }
}
