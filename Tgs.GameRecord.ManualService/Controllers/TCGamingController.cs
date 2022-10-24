using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.TCGaming;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("TCG")]
[ApiController]
public class TCGamingController : ControllerBase
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
    ///             "subGP": "TCG_LOTTO",
    ///             "merchantCode": "pegacnys",
    ///             "isDesignation": true,
    ///             "LastGameRecordDirectory": "20220113",
    ///             "LastGameRecordFile": "202201131345_0001.json"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<TCGamingResultViewModel> GameRecordAsync(
        [FromServices] IGetService<TCGamingQuery, TCGamingResult> service,
         TCGamingQueryViewModel source)
    {
        var result = await service.GetAsync(new TCGamingQuery()
        {
            IsDesignation = source.IsDesignation,
            SubGP = source.SubGP,
            MerchantCode = source.MerchantCode,
            LastGameRecordDirectory = source.LastGameRecordDirectory,
            LastGameRecordFile = source.LastGameRecordFile
        }).ConfigureAwait(false);

        return new TCGamingResultViewModel()
        {
            Success = result.Success,
            LastGameRecordDirectory = result.LastGameRecordDirectory,
            LastGameRecordFile = result.LastGameRecordFile
        };
    }
}
