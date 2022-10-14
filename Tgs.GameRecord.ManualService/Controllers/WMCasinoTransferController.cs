using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.WMCasinoTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("wmtf")]
[ApiController]
public class WMCasinoTransferController : ControllerBase
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
    ///             "apiUrl": "https://api.a45.me/api/public/Gateway.php",
    ///             "gameProviderVendorId": "hpg02twapi",
    ///             "gameProviderSignature": "89448b444ed2e922ddc3aa0753370238",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<WMCasinoTransferResultViewModel> GameRecordAsync(
        [FromServices] IGetService<WMCasinoTransferRequest, WMCasinoTransferResponse> service,
         WMCasinoTransferQueryViewModel model)
    {
        var result = await service.GetAsync(new WMCasinoTransferRequest(
            GameApiUrl: model.ApiUrl,
            GameProviderVendorId: model.GameProviderVendorId,
            GameProviderSignature: model.GameProviderSignature,
            StartTime: model.StartTime,
            EndTime: model.EndTime)).ConfigureAwait(false);

        return new WMCasinoTransferResultViewModel()
        {
            Success = result.Success,
        };
    }
}
