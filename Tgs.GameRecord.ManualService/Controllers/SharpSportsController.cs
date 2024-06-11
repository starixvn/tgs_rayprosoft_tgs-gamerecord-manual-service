using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;
[Route("Sharp_Sports")]
[ApiController]
public class SharpSportsController : ControllerBase
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
	///				"ApiUrl": "https://api.98ktest.com/",
	///				"MerchantId": "c6a33e4e235e731b51d2f303199edeb4",
	///				"ClientId": "2a954fedf9a203d646e1a7f3c32528df",
	///				"ClientSecret": "1ff45c6ed7494b04940dc0bd9e0dca6b",
	///				"StartTime": "2024-06-05T16:00:00+00:00",
	///				"EndTime": "2024-06-06T16:00:00+00:00"
	///         }
	/// </remarks>
	[HttpPost]
	public ValueTask GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		SharpSportsViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.MerchantId,
			source.ClientId,
			source.ClientSecret,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.sharpsports.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
