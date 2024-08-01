using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Valhalla.MessageQueue;
using Tgs.GameRecord.ManualService.ViewModels;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("CR")]
[ApiController]
public class CRSportsController : ControllerBase
{
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		CRSportsViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.AgentId,
			source.SecretKey,
			source.AgentAccount,
			source.AgentPassword,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.cr.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
