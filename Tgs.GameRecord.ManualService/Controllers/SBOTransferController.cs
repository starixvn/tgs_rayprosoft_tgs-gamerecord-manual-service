using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.SBOTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("sbotf")]
[ApiController]
public class SBOTransferController : ControllerBase
{
    /// <summary>
    /// Games the record by sports book asynchronous.
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
    ///             "apiUrl": "https://ex-api-demo-yy.568win.com",
    ///             "companyKey": "49ED28A987624CA0A3F834C3B8A69AAB",
    ///             "agent": "STAG_GPI_CNY",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("sportsbook")]
    public async ValueTask<SBOTransferResultViewModel> GameRecordBySportsBookAsync(
        [FromServices] IGetService<SBOTransferQuery, SBOTransferResult> service,
         SBOTransferQueryViewModel source)
    {
        var result = await service.GetAsync(new SBOTransferQuery(
                ApiUrl: source.ApiUrl,
                CompanyKey: source.CompanyKey,
                Agent: source.Agent,
                Portfolio: "SportsBook",
                StartTime: source.StartTime,
                EndTime: source.EndTime)).ConfigureAwait(false);

        return new SBOTransferResultViewModel()
        {
            Success = result.Success,
        };
    }

    /// <summary>
    /// Games the record by virtual sports asynchronous.
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
    ///             "apiUrl": "https://ex-api-demo-yy.568win.com",
    ///             "companyKey": "49ED28A987624CA0A3F834C3B8A69AAB",
    ///             "agent": "STAG_GPI_CNY",
    ///             "startTime": "2022-09-22T16:30:00+08:00",
    ///             "endTime": "2022-09-22T17:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("virtualsports")]
    public async ValueTask<SBOTransferResultViewModel> GameRecordByVirtualSportsAsync(
        [FromServices] IGetService<SBOTransferQuery, SBOTransferResult> service,
         SBOTransferQueryViewModel source)
    {
        var result = await service.GetAsync(new SBOTransferQuery(
                ApiUrl: source.ApiUrl,
                CompanyKey: source.CompanyKey,
                Agent: source.Agent,
                Portfolio: "VirtualSports",
                StartTime: source.StartTime,
                EndTime: source.EndTime)).ConfigureAwait(false);

        return new SBOTransferResultViewModel()
        {
            Success = result.Success,
        };
    }
}
