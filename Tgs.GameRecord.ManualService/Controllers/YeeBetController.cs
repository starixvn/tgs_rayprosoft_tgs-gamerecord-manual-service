using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.YeeBet;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("[controller]")]
[ApiController]
public class YeeBetController : ControllerBase
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
    ///             "apiUrl": "http://api.98kbus.top/",
    ///             "appId": "xtdA15OTVGEP",
    ///             "secretKey": "4885366DF30D880224FF6AA46FBDE4F0",
    ///             "beginTime": "2023-04-10T10:00:00+08:00",
    ///             "endTime": "2023-04-10T11:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<GameRecorResultViewModel> GameRecordAsync(
            [FromServices] IGetService<YeeBetQuery, YeeBetResult> service,
            YeeBetViewModel source)
    {
        var result = await service.GetAsync(new YeeBetQuery(
            ApiUrl: source.ApiUrl,
            AppId: source.AppId,
            SecretKey: source.SecretKey,
            BeginTime: source.BeginTime,
            EndTime: source.EndTime), HttpContext.RequestAborted).ConfigureAwait(false);

        return new GameRecorResultViewModel
        {
            Success = result.Success
        };
    }
}
