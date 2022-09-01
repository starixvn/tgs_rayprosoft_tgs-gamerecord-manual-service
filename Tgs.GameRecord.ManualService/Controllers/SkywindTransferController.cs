using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.SkywindTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("swtf")]
[ApiController]
public class SkywindTransferController : ControllerBase
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
    ///             "gameApiUrl": "https://api.gcpstg.m27613.com/",
    ///             "secretKey": "66a44892-54dc-488b-b755-1d1da4f8ad61",
    ///             "username": "PGT_brand_api_stg",
    ///             "password": "ArSg5e6CR2g1wIgB",
    ///             "startDate": "2022-08-25T11:00:00+08:00",
    ///             "endDate": "2022-08-25T11:10:00+08:00"
    ///          }
    /// </remarks>
    [HttpPost]
    public async ValueTask<SkywindTransferResultViewModel> GameRecordAsync(
        [FromServices] IGetService<SkywindTransferRequest, SkywindTransferResponse> service,
        SkywindTransferQueryViewModel model)
    {
        var request = new SkywindTransferRequest(
            model.GameApiUrl,
            model.SecretKey,
            model.Username,
            model.Password,
            model.StartDate,
            model.EndDate);
        var result = await service.GetAsync(
            request,
            HttpContext.RequestAborted
            ).ConfigureAwait(false);

        return new SkywindTransferResultViewModel()
        {
            Success = result.Success,
        };
    }
}
