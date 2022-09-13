using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.JDBTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("jdbtf")]
[ApiController]
public class JDBTransferController : ControllerBase
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
    ///             "apiUrl": "http://api.jygrq.com",
    ///             "domain": "ZF",
    ///             "aesKey": "831057181dd07807",
    ///             "aesIV": "193a3159afebee65",
    ///             "agent": "zf055gpi",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<JDBTransferResultViewModel> GameRecordAsync(
        [FromServices] IGetService<JDBTransferRequest, JDBTransferResponse> service,
         JDBTransferQueryViewModel source)
    {
        var result = await service.GetAsync(new JDBTransferRequest(
                ApiUrl: source.ApiUrl,
                Domain: source.Domain,
                AesKey: source.AesKey,
                AesIV: source.AesIV,
                Agent: source.Agent,
                StartTime: source.StartTime,
                EndTime: source.EndTime)).ConfigureAwait(false);

        return new JDBTransferResultViewModel()
        {
            Success = result.Success,
        };
    }
}
