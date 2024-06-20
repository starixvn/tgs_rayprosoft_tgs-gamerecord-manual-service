using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;
[Route("GA28")]
[ApiController]
public class GA28Controller : ControllerBase
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
	///				"apiUrl": "http://partner-api.dev.ga28.cc",
	///				"privateKey": "8456c9de-d589-4e8a-876f-c9c8e48dda3e",
	///				"partnerAccountId": "99a6f8ef-38a6-4f31-b69a-e222c2a54771",
	///				"startTime": "2024-06-18T10:00:00+08:00",
	///				"endTime": "2024-06-18T11:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		GA28ViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.PrivateKey,
			source.PartnerAccountId,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.ga28.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
