using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("im_esp")]
[ApiController]
public class IMESportsController : ControllerBase
{
	/// <summary>
	/// Games the record asynchronous.
	/// </summary>
	/// <param name="messageSender"></param>
	/// <param name="source"></param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///         {
	///             "reportUrl":"http://operatorapi-report.staging.imaegisapi.com/",
	///             "merchantCode":"OfL5H2hKOIP9tHp9ZIoqYeggJtFC39zQ",
	///             "merchantPrefix":"IM1S3",
	///             "startTime": "2023-04-27T13:00:00+08:00",
	///             "endTime": "2023-04-27T14:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		InplayMatrixESportsViewModel source)
	{
		var parameters = new
		{
			GameProviderCode = "IM_ESP",
			source.ReportUrl,
			source.MerchantCode,
			source.MerchantPrefix,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.im.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
