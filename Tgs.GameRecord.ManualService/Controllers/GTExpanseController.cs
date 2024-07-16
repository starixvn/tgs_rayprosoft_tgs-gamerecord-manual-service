using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;
[Route("GT_Expanse")]
[ApiController]
public class GTExpanseController : ControllerBase
{
	/// <summary>
	/// Games the record asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		GTExpanseViewModel source)
	{
		var parameters = new
		{
			GameProviderCode = "GT_EPS",
			source.DataApiUrl,
			source.BrandId,
			source.SecretKey,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.gt.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
