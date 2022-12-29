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
    ///             "apiUrl":"https://cn.ucfclive.com/",
    ///             "merchantId":"SQjCxm2cX5bahBta",
    ///             "merchantKey":"XGKGkcmYNnfex8AecKzCEbD4GMExA2cb",
    ///             "startTime": "2022-12-28T17:00:00+08:00",
    ///             "endTime": "2022-12-28T17:30:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<GameRecorResultViewModel> GameRecordAsync(
        [FromServices] IGetService<SM01Query, SM01Result> service,
         SM01QueryViewModel source)
    {
        var result = await service.GetAsync(new SM01Query(
            ApiUrl: source.ApiUrl,
            MerchantId: source.MerchantId,
            MerchantKey: source.MerchantKey,
            StartTime: source.StartTime,
            EndTime: source.EndTime),
            HttpContext.RequestAborted).ConfigureAwait(false);

        return new GameRecorResultViewModel()
        {
            Success = result.Success,
        };
    }
}
