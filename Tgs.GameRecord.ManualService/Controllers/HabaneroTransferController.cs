using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.HabaneroTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("habatf")]
[ApiController]
public class HabaneroTransferController : ControllerBase
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
    ///             "apiUrl": "https://asia-east2-bq-data-api.cloudfunctions.net/",
    ///             "brandId": "b97e1834-d142-ed11-a27c-0050f23876f7",
    ///             "apiKey": "0F0B9E83-80FF-4DC7-8C8C-DF48B55DAE45",
    ///             "startTime": "2022-10-27T06:31:00+08:00",
    ///             "endTime": "2022-10-27T06:36:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<HabaneroTransferResultViewModel> GameRecordAsync(
        [FromServices] IGetService<HabaneroTransferQuery, HabaneroTransferResult> service,
         HabaneroTransferQueryViewModel source)
    {
        var result = await service.GetAsync(new HabaneroTransferQuery(
            ApiUrl: source.ApiUrl,
            BrandId: source.BrandId,
            ApiKey: source.ApiKey,
            StartTime: source.StartTime,
            EndTime: source.EndTime)).ConfigureAwait(false);

        return new HabaneroTransferResultViewModel
        {
            Success = result.Success
        };
    }
}
