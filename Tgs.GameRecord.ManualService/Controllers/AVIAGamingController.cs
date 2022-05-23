using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.AVIAGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers
{
    [Route("AVIA")]
    [ApiController]
    public class AVIAGamingController : ControllerBase
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
        ///             "startTime":"2021-12-30T01:00:00+00:00",
        ///             "endTime":"2021-12-30T02:00:00+00:00"
        ///         }
        /// </remarks>
        [HttpPost]
        public async ValueTask<AVIAGamingResultViewModel> GameRecordAsync(
            [FromServices] IGetService<AVIAGamingRequest, AVIAGamingResponse> service,
             AVIAGamingQueryViewModel model)
        {
            var result = await service.GetAsync(new AVIAGamingRequest()
            {
                BrandCode = model.BrandCode,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            }).ConfigureAwait(false);

            return new AVIAGamingResultViewModel()
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
