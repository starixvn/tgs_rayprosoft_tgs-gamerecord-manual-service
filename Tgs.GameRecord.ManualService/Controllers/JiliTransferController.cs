using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("jilitf")]
[ApiController]
public class JiliTransferController : ControllerBase
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
	///             "apiUrl":"https://uat-wb-api.jlfafafa2.com/",
	///             "gameProviderAgentId":"PG_GPI_CNY",
	///             "gameProviderAgentKey":"82af5971ae233eaa003b774be4079e7902ea7ff4",
	///             "startTime": "2024-01-03T11:00:00+08:00",
	///             "endTime": "2024-01-03T11:10:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		JiliTransferQueryViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			AgentId = source.GameProviderAgentId,
			AgentKey = source.GameProviderAgentKey,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.jili.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
