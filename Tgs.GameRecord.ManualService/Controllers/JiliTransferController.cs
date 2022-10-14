using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.JiliTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("jilitf")]
[ApiController]
public class JiliTransferController : ControllerBase
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
    ///             "apiUrl":"https://uat-wb-api.jlfafafa2.com/",
    ///             "gameProviderAgentId":"PG_GPI_CNY",
    ///             "gameProviderAgentKey":"82af5971ae233eaa003b774be4079e7902ea7ff4",
    ///             "startTime": "2022-09-07T18:50:00+08:00",
    ///             "endTime": "2022-09-07T18:55:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public async ValueTask<JiliTransferResultViewModel> GameRecordAsync(
        [FromServices] IGetService<JiliTransferRequest, JiliTransferResponse> service,
         JiliTransferQueryViewModel model)
    {
        var result = await service.GetAsync(new JiliTransferRequest(
            GameApiUrl: model.ApiUrl,
            GameProviderAgentId: model.GameProviderAgentId,
            GameProviderAgentKey: model.GameProviderAgentKey,
            StartTime: model.StartTime,
            EndTime: model.EndTime)).ConfigureAwait(false);

        return new JiliTransferResultViewModel()
        {
            Success = result.Success,
        };
    }
}
