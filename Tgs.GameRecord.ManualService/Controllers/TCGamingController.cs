using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.TCGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers
{
    [Route("TCG")]
    [ApiController]
    public class TCGamingController : ControllerBase
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
        ///             "subGP": "TCG_LOTTO",
        ///             "merchantCode": "pegacnys",
        ///             "isDesignation": true,
        ///             "lastGameRecorDirectory": "20220113",
        ///             "lastGameRecorFile": "202201131345_0001.json"
        ///         }
        /// </remarks>
        [HttpPost]
        public async ValueTask<TCGamingResultViewModel> GameRecordAsync(
            [FromServices] IGetService<TCGamingRequest, TCGamingResponse> service,
             TCGamingQueryViewModel model)
        {
            var result = await service.GetAsync(new TCGamingRequest()
            {
                IsDesignation = model.IsDesignation,
                SubGP = model.SubGP,
                MerchantCode = model.MerchantCode,
                LastGameRecorDirectory = model.LastGameRecorDirectory,
                LastGameRecorFile = model.LastGameRecorFile
            }).ConfigureAwait(false);

            return new TCGamingResultViewModel()
            {
                Success = result.Success,
                LastGameRecorDirectory = result.LastGameRecorDirectory,
                LastGameRecorFile = result.LastGameRecorFile
            };
        }
    }
}
