using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.WGViaGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers
{
    [Route("WGVIA")]
    [ApiController]
    public class WGViaGamingController : ControllerBase
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
        public async ValueTask<WGViaGamingResultViewModel> GameRecordAsync(
            [FromServices] IGetService<WGViaGamingRequest, WGViaGamingResponse> service,
             WGViaGamingQueryViewModel model)
        {
            var result = await service.GetAsync(new WGViaGamingRequest()
            {
                StartTime = model.StartTime,
                EndTime = model.EndTime
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
}
