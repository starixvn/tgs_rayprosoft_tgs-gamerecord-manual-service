using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.JiliTransfer;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.SabaTransfer;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.SBOTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("sabatf")]
[ApiController]
public class SabaTransferController : ControllerBase
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
    ///             "apiUrl": "http://h0i2tsa.bw6688.com/",
    ///             "operatorId": "tg",
    ///             "vendorId": "um5vspnzkx",
    ///             "startTime": "2022-10-27T15:50:00+08:00",
    ///             "endTime": "2022-10-27T15:55:00+08:00
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<GameRecorResultViewModel> GameRecordAsync(
        [FromServices] IGetService<SabaTransferQuery, SabaTransferResult> service,
         SabaTransferQueryViewModel source)
    {
        var result = await service.GetAsync(new SabaTransferQuery(
            ApiUrl: source.ApiUrl,
            OperatorId: source.OperatorId,
            VendorId: source.VendorId,
            StartTime: source.StartTime,
            EndTime: source.EndTime)).ConfigureAwait(false);

        return new GameRecorResultViewModel()
        {
            Success = result.Success,
        };
    }
}
