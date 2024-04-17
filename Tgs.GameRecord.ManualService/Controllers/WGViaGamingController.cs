using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("WGVIA")]
[ApiController]
public class WGViaGamingController : ControllerBase
{
	/// <summary>
	/// Games the record asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": "https://via.itd888.com/",
	///             "partnerCode": "PT",
	///             "partnerKey": "a888888888888888",
	///             "partnerIV": "b888888888888888",
	///             "startTime": "2023-06-28T00:00:00+08:00",
	///             "endTime": "2023-06-29T00:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		 WGViaGamingQueryViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.PartnerCode,
			SecretKey = source.PartnerKey,
			SecretIV = source.PartnerIV,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.wgvia.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
