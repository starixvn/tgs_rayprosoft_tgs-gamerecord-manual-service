using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.EvolutionTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("evotfo")]
[ApiController]
public class EvolutionTransferController : ControllerBase
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
    ///             "apiUrl":"https://babylonpega2.uat1.evo-test.com/",
    ///             "casinoId":"babylonpega20001",
    ///             "gameHistoryApiToken":"test123",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<EvolutionTransferResultViewModel> GameRecordAsync(
        [FromServices] IGetService<EvolutionTransferRequest, EvolutionTransferResponse> service,
         EvolutionTransferQueryViewModel model)
    {
        var result = await service.GetAsync(new EvolutionTransferRequest(
            GameApiUrl: model.ApiUrl,
            CasinoId: model.CasinoId,
            GameHistoryApiToken: model.GameHistoryApiToken,
            StartDate: model.StartTime,
            EndDate: model.EndTime)).ConfigureAwait(false);

        return new EvolutionTransferResultViewModel()
        {
            Success = result.Success,
        };
    }
}
