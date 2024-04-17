using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("swtf")]
[ApiController]
public class SkywindTransferController : ControllerBase
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
	///         {
	///             "apiUrl": "https://api.gcpstg.m27613.com/",
	///             "secretKey": "66a44892-54dc-488b-b755-1d1da4f8ad61",
	///             "username": "PGT_brand_api_stg",
	///             "password": "ArSg5e6CR2g1wIgB",
	///             "startTime": "2024-01-05T14:00:00+08:00",
	///             "endTime": "2024-01-05T15:00:00+08:00"
	///          }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		SkywindTransferQueryViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.SecretKey,
			source.Username,
			source.Password,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.swtf.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
