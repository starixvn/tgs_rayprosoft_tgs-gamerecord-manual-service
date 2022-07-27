using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;
using Tgs.GameRecord.ManualService.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("PPTF")]
[ApiController]
public class PragmaticPlayTransferController : ControllerBase
{
    /// <summary>
    /// Games the record by fishing asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "startTime":"2022-07-26T22:00:00+08:00",
    ///             "endTime":"2022-07-26T23:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("Fishing")]
    public async ValueTask<PragmaticPlayTransferResultViewModel> GameRecordByFishingAsync(
        [FromServices] IGetService<PragmaticPlayTransferRequest, PragmaticPlayTransferResponse> service,
        PragmaticPlayTransferQueryViewModel model)
    {
        var request = new PragmaticPlayTransferRequest(
            DataType: PragmaticPlayTransferDataType.Fishing,
            StartTime: model.StartTime,
            EndTime: model.EndTime);

        var result = await service.GetAsync(query: request).ConfigureAwait(false);

        return new PragmaticPlayTransferResultViewModel
        {
            Success = result.Success,
            Message = result.Message,
            NextTime = result.NextTime,
            LastGameRecordTime = result.LastGameRecordTime
        };
    }

    /// <summary>
    /// Games the record by live dealer asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "startTime":"2022-07-26T22:00:00+08:00",
    ///             "endTime":"2022-07-26T23:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("LiveDealer")]
    public async ValueTask<PragmaticPlayTransferResultViewModel> GameRecordByLiveDealerAsync(
        [FromServices] IGetService<PragmaticPlayTransferRequest, PragmaticPlayTransferResponse> service,
        PragmaticPlayTransferQueryViewModel model)
    {
        var request = new PragmaticPlayTransferRequest(
            DataType: PragmaticPlayTransferDataType.LiveDealer,
            StartTime: model.StartTime,
            EndTime: model.EndTime);

        var result = await service.GetAsync(query: request).ConfigureAwait(false);

        return new PragmaticPlayTransferResultViewModel
        {
            Success = result.Success,
            Message = result.Message,
            NextTime = result.NextTime,
            LastGameRecordTime = result.LastGameRecordTime
        };
    }

    /// <summary>
    /// Games the record by RNG asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "startTime":"2022-07-26T22:00:00+08:00",
    ///             "endTime":"2022-07-26T23:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("RNG")]
    public async ValueTask<PragmaticPlayTransferResultViewModel> GameRecordByRNGAsync(
        [FromServices] IGetService<PragmaticPlayTransferRequest, PragmaticPlayTransferResponse> service,
        PragmaticPlayTransferQueryViewModel model)
    {
        var request = new PragmaticPlayTransferRequest(
            DataType: PragmaticPlayTransferDataType.RNG,
            StartTime: model.StartTime,
            EndTime: model.EndTime);

        var result = await service.GetAsync(query: request).ConfigureAwait(false);

        return new PragmaticPlayTransferResultViewModel
        {
            Success = result.Success,
            Message = result.Message,
            NextTime = result.NextTime,
            LastGameRecordTime = result.LastGameRecordTime
        };
    }

    /// <summary>
    /// Games the record by virtual sports asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "startTime":"2022-07-26T22:00:00+08:00",
    ///             "endTime":"2022-07-26T23:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost("VirtualSports")]
    public async ValueTask<PragmaticPlayTransferResultViewModel> GameRecordByVirtualSportsAsync(
        [FromServices] IGetService<PragmaticPlayTransferRequest, PragmaticPlayTransferResponse> service,
        PragmaticPlayTransferQueryViewModel model)
    {
        var request = new PragmaticPlayTransferRequest(
            DataType: PragmaticPlayTransferDataType.VirtualSports,
            StartTime: model.StartTime,
            EndTime: model.EndTime);

        var result = await service.GetAsync(query: request).ConfigureAwait(false);

        return new PragmaticPlayTransferResultViewModel
        {
            Success = result.Success,
            Message = result.Message,
            NextTime = result.NextTime,
            LastGameRecordTime = result.LastGameRecordTime
        };
    }
}
