using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.EvolutionTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("evotf")]
[ApiController]
public class EvolutionTransferController : ControllerBase
{
    /// <summary>
    /// Games the record asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
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
    public async ValueTask<GameRecorResultViewModel> GameRecordAsync(
        [FromServices] IGetService<EvolutionTransferQuery, EvolutionTransferResult> service,
         EvolutionTransferQueryViewModel source)
    {
        var result = await service.GetAsync(new EvolutionTransferQuery(
            GameApiUrl: source.ApiUrl,
            CasinoId: source.CasinoId,
            GameHistoryApiToken: source.GameHistoryApiToken,
            StartDate: source.StartTime,
            EndDate: source.EndTime)).ConfigureAwait(false);

        return new GameRecorResultViewModel()
        {
            Success = result.Success,
        };
    }
}
