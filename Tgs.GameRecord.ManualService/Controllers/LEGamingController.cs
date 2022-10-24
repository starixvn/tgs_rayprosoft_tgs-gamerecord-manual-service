using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.LEGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("LY")]
[ApiController]
public class LEGamingController : ControllerBase
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
    ///             "brandCode": "Default",
    ///             "currencyCode": "HKD",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<LEGamingResultViewModel> GameRecordAsync(
        [FromServices] IGetService<LEGamingQuery, LEGamingResult> service,
         LEGamingQueryViewModel source)
    {
        var result = await service.GetAsync(new LEGamingQuery()
        {
            BrandCode = source.BrandCode,
            CurrencyCode = source.CurrencyCode,
            StartTime = source.StartTime,
            EndTime = source.EndTime
        }).ConfigureAwait(false);

        return new LEGamingResultViewModel()
        {
            Success = result.Success,
            LastGameRecordTime = result.LastGameRecordTime,
            SuccessCount = result.SuccessCount,
            FailureCount = result.FailureCount,
            Count = result.Count,
        };
    }
}
