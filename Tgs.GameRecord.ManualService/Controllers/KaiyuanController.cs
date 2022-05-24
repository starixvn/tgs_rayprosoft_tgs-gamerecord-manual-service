using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.Kaiyuan;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers
{
    [Route("KY")]
    [ApiController]
    public class KaiyuanController : ControllerBase
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
        ///             "brandCode":"Default",
        ///             "currencyCode":"CNY",
        ///             "startTime":"2021-12-30T01:00:00+00:00",
        ///             "endTime":"2021-12-30T02:00:00+00:00"
        ///         }
        /// </remarks>
        [HttpPost]
        public async ValueTask<KaiyuanResultViewModel> GameRecordAsync(
            [FromServices] IGetService<KaiyuanRequest, KaiyuanResponse> service,
             KaiyuanQueryViewModel model)
        {
            var result = await service.GetAsync(new KaiyuanRequest()
            {
                BrandCode = model.BrandCode,
                CurrencyCode = model.CurrencyCode,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            }).ConfigureAwait(false);

            return new KaiyuanResultViewModel()
            {
                Success = result.Success,
                LastGameRecordTime = result.LastGameRecordTime,
                SuccessCount = result.SuccessCount,
                FailureCount = result.FailureCount,
                Count = result.Count,
            };
        }
    }
}
