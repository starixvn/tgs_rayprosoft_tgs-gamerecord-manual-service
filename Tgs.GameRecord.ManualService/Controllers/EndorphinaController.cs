using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.Endorphina;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("Endor")]
[ApiController]
public class EndorphinaController : ControllerBase
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
    ///             "apiUrl":"https://test.endorphina.network",
    ///             "merchantId":"1494",
    ///             "secretKey":"9BC9E97FFCD74B16B87BD6FA82C8C2AF",
    ///             "token":"AA8BB60F5A134264BE838CF6EBA7C8F1"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<GameRecorResultViewModel> GameRecordAsync(
        [FromServices] IGetService<EndorphinaQuery, EndorphinaResult> service,
        EndorphinaQueryViewModel source)
    {
        var result = await service.GetAsync(new EndorphinaQuery(
            ApiUrl: source.ApiUrl,
            MerchantId: source.MerchantId,
            SecretKey: source.SecretKey,
            Token: source.Token), HttpContext.RequestAborted).ConfigureAwait(false);

        return new GameRecorResultViewModel
        {
            Success = result.Success
        };
    }
}
