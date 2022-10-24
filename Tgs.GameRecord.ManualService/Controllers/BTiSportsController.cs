using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.BTiSports;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("bti")]
[ApiController]
public class BTiSportsController : ControllerBase
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
    ///
    ///         {
    ///             "tokenApiUrl": "https://asia-east2-bq-data-api.cloudfunctions.net/",
    ///             "openBetsApiUrl": "https://get-open-bets-d5nlg5buca-de.a.run.app/",
    ///             "historyBetsPagingApiUrl": "https://get-history-bets-paging-d5nlg5buca-de.a.run.app/",
    ///             "agentUserName": "PegaGaming_GPIRMB",
    ///             "agentPassword": "IM60Ho7Y4B9C",
    ///             "startTime": "2022-10-24T00:00:00+08:00",
    ///             "endTime": "2022-10-25T00:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<BTiSportsResultViewModel> GameRecordAsync(
        [FromServices] IGetService<BTiSportsQuery, BTiSportsResult> service,
         BTiSportsQueryViewModel source)
    {
        var result = await service.GetAsync(new BTiSportsQuery(
            TokenApiUrl: source.TokenApiUrl,
            OpenBetsApiUrl: source.OpenBetsApiUrl,
            HistoryBetsPagingApiUrl: source.HistoryBetsPagingApiUrl,
            AgentUserName: source.AgentUserName,
            AgentPassword: source.AgentPassword,
            StartTime: source.StartTime,
            EndTime: source.EndTime)).ConfigureAwait(false);

        return new BTiSportsResultViewModel()
        {
            Success = result.Success
        };
    }
}
