using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.WGFmGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("WGFM")]
[ApiController]
public class WGFmGamingController : ControllerBase
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
    ///             "apiUrl": "https://api.jsc080.net/",
    ///             "partnerCode": "TA",
    ///             "partnerKey": "abc1238888888888",
    ///             "partnerIV": "cba1238888888888",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<WGFmGamingResultViewModel> GameRecordAsync(
        [FromServices] IGetService<WGFmGamingRequest, WGFmGamingResponse> service,
         WGFmGamingQueryViewModel model)
    {
        var result = await service.GetAsync(new WGFmGamingRequest(
            model.ApiUrl,
            model.PartnerCode,
            model.PartnerKey,
            model.PartnerIV,
            model.StartTime,
            model.EndTime)).ConfigureAwait(false);

        return new WGFmGamingResultViewModel()
        {
            Success = result.Success
        };
    }
}
