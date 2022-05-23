using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.LEGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers
{
    [Route("LY")]
    [ApiController]
    public class LEGamingController : ControllerBase
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
        ///             "brandCode": "Default",
        ///             "currencyCode": "HKD",
        ///             "startTime": "2021-11-02T03:00:00+00:00",
        ///             "endTime": "2021-11-02T04:00:00+00:00"
        ///         }
        /// </remarks>
        [HttpPost]
        public async ValueTask<LEGamingResultViewModel> GameRecordAsync(
            [FromServices] IGetService<LEGamingRequest, LEGamingResponse> service,
             LEGamingQueryViewModel model)
        {
            var result = await service.GetAsync(new LEGamingRequest()
            {
                BrandCode = model.BrandCode,
                CurrencyCode = model.CurrencyCode,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            }).ConfigureAwait(false);

            return new LEGamingResultViewModel()
            {
                Success = result.Success,
                LastGameRecordTime = result.LastGameRecordTime,
                SuccessCount = result.SuccessCount,
                FailCount = result.FailCount,
                Count = result.Count,
            };
        }
    }
}
