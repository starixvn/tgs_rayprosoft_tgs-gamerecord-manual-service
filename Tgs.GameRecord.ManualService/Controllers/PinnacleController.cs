using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("[controller]")]
[ApiController]
public class PinnacleController : ControllerBase
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
	///             "apiUrl": "https://paapistg.oreo88.com",
	///             "agentCode": "V0201",
	///             "agentKey": "8d0e9ac0-99d8-48c7-8307-bc328c4181f6",
	///             "secretKey": "zenDIdY7Knuzmeen",
	///             "startTime": "2023-05-23T19:25:00+08:00",
	///             "endTime": "2023-05-23T19:30:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		PinnacleViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.AgentCode,
			source.AgentKey,
			source.SecretKey,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.pinnacle.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
