using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.BigGamingFishing;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("BG")]
[ApiController]
public class BigGamingController : ControllerBase
{
    /// <summary>
    /// Games the record asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "currencyCode":"CNY",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("Fishing")]
    public async ValueTask<BigGamingFishingResultViewModel> GameRecordAsync(
        [FromServices] IGetService<BigGamingFishingRequest, BigGamingFishingResponse> service,
         BigGamingFishingQueryViewModel model)
    {
        var result = await service.GetAsync(new BigGamingFishingRequest()
        {
            CurrencyCode = model.CurrencyCode,
            StartTime = model.StartTime,
            EndTime = model.EndTime
        }).ConfigureAwait(false);

        return new BigGamingFishingResultViewModel()
        {
            Success = result.Success,
            LastGameRecordTime = result.LastGameRecordTime,
            SuccessCount = result.SuccessCount,
            FailureCount = result.FailureCount,
            Count = result.Count,
        };
    }
}
