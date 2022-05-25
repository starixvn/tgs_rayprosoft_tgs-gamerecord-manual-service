using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.WGFmGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers
{
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
        ///             "startTime": "2021-10-31T16:00:00+00:00",
        ///             "endTime": "2022-11-30T16:00:00+00:00"
        ///         }
        /// </remarks>
        [HttpPost]
        public async ValueTask<WGFmGamingResultViewModel> GameRecordAsync(
            [FromServices] IGetService<WGFmGamingRequest, WGFmGamingResponse> service,
             WGFmGamingQueryViewModel model)
        {
            var result = await service.GetAsync(new WGFmGamingRequest()
            {
                StartTime = model.StartTime,
                EndTime = model.EndTime
            }).ConfigureAwait(false);

            return new WGFmGamingResultViewModel()
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
