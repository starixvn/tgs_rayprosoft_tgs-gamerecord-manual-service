using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.Joker;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers
{
    [Route("Joker")]
    [ApiController]
    public class JokerController : ControllerBase
    {
        /// <summary>
        /// Games the record asynchronous.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <remarks>
        /// <b>Example</b><br/>
        ///
        ///     Post
        ///         {
        ///             "brandCode": "Default",
        ///             "agentId": "TGVY",
        ///             "startTime": "2021-11-30T16:00:00+00:00",
        ///             "endTime": "2021-12-31T16:00:00+00:00"
        ///         }
        /// </remarks>
        [HttpPost]
        public async ValueTask<JokerResultViewModel> GameRecordAsync(
            [FromServices] IGetService<JokerRequest, JokerResponse> service,
            JokerQueryViewModel model)
        {
            var result = await service.GetAsync(new JokerRequest()
            {
                BrandCode = model.BrandCode,
                AgentId = model.AgentId,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            }).ConfigureAwait(false);

            return new JokerResultViewModel()
            {
                Success = result.Success,
                LastGameRecorTime = result.LastGameRecorTime,
                SuccessCount = result.SuccessCount,
                FailCount = result.FailCount,
                Count = result.Count,
            };
        }
    }
}
