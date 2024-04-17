using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("FaChai")]
[ApiController]
public class FaChaiController : ControllerBase
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
	///             "apiUrl":"http://api.fcg666.net/",
	///             "agentCode":"GPICN",
	///             "agentKey":"EOJC9q31Y7AnPb9i",
	///             "currency":"CNY",
	///             "startTime": "2023-03-13T15:45:00+08:00",
	///             "endTime": "2023-03-13T16:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		FaChaiViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.AgentCode,
			source.AgentKey,
			source.Currency,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.fachai.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
