using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.AVIAGaming;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("PPTF")]
[ApiController]
public class PragmaticPlayTransferController : ControllerBase
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
    ///             "dataType":"RNG",
    ///             "startTime":"2021-12-30T01:00:00+00:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<PragmaticPlayTransferResultViewModel> GameRecordAsync(
        [FromServices] IGetService<PragmaticPlayTransferRequest, PragmaticPlayTransferResponse> service,
        PragmaticPlayTransferQueryViewModel model)
    {
        var result = await service.GetAsync(new PragmaticPlayTransferRequest
        {
            DataType = model.DataType,
            StartTime = model.StartTime
        }).ConfigureAwait(false);

        return new PragmaticPlayTransferResultViewModel
        {
            Success = result.Success,
            LastGameRecordTime = result.LastGameRecordTime,
            SuccessCount = result.SuccessCount,
            FailureCount = result.FailureCount,
            Count = result.Count,
            NextTime = result.NextTime
        };
    }
}
