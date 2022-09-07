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
    ///             "gameApiUrl":"https://babylonpega2.uat1.evo-test.com/",
    ///             "casinoId":"babylonpega20001",
    ///             "gameHistoryApiToken":"test123",
    ///             "startDate": "2022-07-15T10:00:00.000Z",
    ///             "endDate": "2022-07-15T11:00:00.000Z"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<EvolutionTransferResultViewModel> GameRecordAsync(
        [FromServices] IGetService<EvolutionTransferRequest, EvolutionTransferResponse> service,
         EvolutionTransferQueryViewModel model)
    {
        var result = await service.GetAsync(new EvolutionTransferRequest(
            GameApiUrl: model.GameApiUrl,
            CasinoId: model.CasinoId,
            GameHistoryApiToken: model.GameHistoryApiToken,
            StartDate: model.StartDate,
            EndDate: model.EndDate)).ConfigureAwait(false);

        return new EvolutionTransferResultViewModel()
        {
            Success = result.Success,
        };
    }
}
