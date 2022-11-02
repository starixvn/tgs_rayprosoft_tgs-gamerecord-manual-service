using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.Awc;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("AWC")]
[ApiController]
public class AwcController : ControllerBase
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
    ///             "gameRecordApiUrl":"https://tttint.onlinegames22.com/",
    ///             "gameProviderCode":"AWC_VENUS",
    ///             "gameProviderAgentId":"cnygpivenus",
    ///             "gameProviderCert":"DfyfVhwJ8akfz2aGo3K",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<GameRecorResultViewModel> GameRecordAsync(
        [FromServices] IGetService<AwcQuery, AwcResult> service,
         AwcQueryViewModel source)
    {
        var result = await service.GetAsync(new AwcQuery(
            GameRecordApiUrl: source.GameRecordApiUrl,
            GameProviderCode: source.GameProviderCode,
            GameProviderAgentId: source.GameProviderAgentId,
            GameProviderCert: source.GameProviderCert,
            StartTime: source.StartTime,
            EndTime: source.EndTime)).ConfigureAwait(false);

        return new GameRecorResultViewModel()
        {
            Success = result.Success,
        };
    }
}
