using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.Awc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers
{
    [Route("AWC")]
    [ApiController]
    public class AwcController : ControllerBase
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
        ///             "gameRecordApiUrl":"https://tttint.onlinegames22.com/",
        ///             "gameProviderCode":"AWC_VENUS",
        ///             "gameProviderAgentId":"cnygpivenus",
        ///             "gameProviderCert":"DfyfVhwJ8akfz2aGo3K",
        ///             "startTime": "2022-05-31T07:00:00.000Z",
        ///             "endTime": "2022-05-31T08:00:00.000Z"
        ///         }
        /// </remarks>
        [HttpPost]
        public async ValueTask<AwcResultViewModel> GameRecordAsync(
            [FromServices] IGetService<AwcRequest, AwcResponse> service,
             AwcQueryViewModel model)
        {
            var result = await service.GetAsync(new AwcRequest(
                GameRecordApiUrl: model.GameRecordApiUrl,
                GameProviderCode: model.GameProviderCode,
                GameProviderAgentId: model.GameProviderAgentId,
                GameProviderCert: model.GameProviderCert,
                StartTime: model.StartTime,
                EndTime: model.EndTime)).ConfigureAwait(false);

            return new AwcResultViewModel()
            {
                Success = result.Success,
            };
        }
    }
}
