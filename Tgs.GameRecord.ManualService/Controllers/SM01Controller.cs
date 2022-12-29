using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.SM01;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("sm01")]
[ApiController]
public class SM01Controller : ControllerBase
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
    ///             "apiUrl":"https://uat-wb-api.jlfafafa2.com/",
    ///             "gameProviderAgentId":"PG_GPI_CNY",
    ///             "gameProviderAgentKey":"82af5971ae233eaa003b774be4079e7902ea7ff4",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<GameRecorResultViewModel> GameRecordAsync(
        [FromServices] IGetService<SM01Query, SM01Result> service,
         SM01QueryViewModel source)
    {
        var result = await service.GetAsync(new SM01Query(
            GameApiUrl: source.ApiUrl,
            GameMerchanttId: source.GameProviderMerchanttId,
            GameMerchantKey: source.GameProviderMerchantKey,
            StartTime: source.StartTime,
            EndTime: source.EndTime)).ConfigureAwait(false);

        return new GameRecorResultViewModel()
        {
            Success = result.Success,
        };
    }
}
