using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("[controller]")]
[ApiController]
public class FunkyController : ControllerBase
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
	///             "apiReportUrl":"http://trial-gp-api-report.funkytest.com/",
	///             "authentication": "c69d57e5-93e7-488c-90a4-e20876b495bc",
	///             "userAgent": "109-PG",
	///             "currency":"CNY",
	///             "startTime": "2024-03-28T17:30:00+08:00",
	///             "endTime": "2024-03-28T18:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		FunkyViewModel source)
	{
		var parameters = new
		{
			ApiUrl = source.ApiReportUrl,
			source.Authentication,
			source.UserAgent,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.funky.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
