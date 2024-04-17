using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("LY")]
[ApiController]
public class LEGamingController : ControllerBase
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
	///             "apiRecordUrl": "https://wc1-record.kewmn686.com/",
	///             "deskey": "706EB65DD6E6DF4C",
	///             "md5key": "3E00054B89B31B7A",
	///             "agentId": "200995",
	///             "startTime": "2023-07-19T15:50:00+08:00",
	///             "endTime": "2023-07-19T16:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		LEGamingViewModel source)
	{
		var parameters = new
		{
			ApiUrl = source.ApiRecordUrl,
			source.Deskey,
			source.Md5key,
			source.AgentId,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.ly.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
