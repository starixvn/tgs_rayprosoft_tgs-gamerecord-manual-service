using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("bti")]
[ApiController]
public class BTiSportsController : ControllerBase
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
	///             "dataApiUrl": "https://data-api.442hattrick.com/",
	///             "agentUserName": "PegaGaming_GPIRMB",
	///             "agentPassword": "IM60Ho7Y4B9C",
	///             "startTime": "2022-10-24T00:00:00+08:00",
	///             "endTime": "2022-10-25T00:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		BTiSportsQueryViewModel source)
	{
		var parameters = new
		{
			source.DataApiUrl,
			source.AgentUserName,
			source.AgentPassword,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.bti.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
