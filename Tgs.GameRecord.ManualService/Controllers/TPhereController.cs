using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.TPhere.Common;

using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("TP")]
[ApiController]
public class TPhereController : ControllerBase
{
	/// <summary>
	/// Games the record betlog asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///		使用遊戲商注單查詢->爬回時間
	///     Post
	///         {
	///				"apiBetUrl": "https://apidemo.tphere.com/",
	///				"apiKey": "6309572cf90658e17847a7b021723106",
	///				"apiToken": "29dad28e8ab9c9855e6aa4b9a9e4a869325931d4976dfcf53266ccbe0c5f3387ea48258c002e3543edbb35f63caa5cacc65ac5c664ccfe0619e1d63018a87dbb",
	///				"startTime": "2024-04-15T14:00:00+08:00",
	///				"endTime": "2024-04-15T14:30:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("betlog")]
	public ValueTask GameRecordBetlogAsync(
		[FromServices] IMessageSender messageSender,
		TPhereViewModel source)
	{
		var parameters = new
		{
			ApiUrl = source.ApiBetUrl,
			source.ApiKey,
			source.ApiToken,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.tp.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}

	/// <summary>
	/// Games the record betlog by bettime asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///		使用遊戲商注單查詢->下注時間
	///     Post
	///         {
	///				"apiBetUrl": "https://apidemo.tphere.com/",
	///				"apiKey": "6309572cf90658e17847a7b021723106",
	///				"apiToken": "29dad28e8ab9c9855e6aa4b9a9e4a869325931d4976dfcf53266ccbe0c5f3387ea48258c002e3543edbb35f63caa5cacc65ac5c664ccfe0619e1d63018a87dbb",
	///				"startTime": "2024-04-15T14:25:00+08:00",
	///				"endTime": "2024-04-15T14:30:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("betlog-by-bettime")]
	public ValueTask GameRecordBetlogByBettimeAsync(
		[FromServices] IMessageSender messageSender,
		TPhereViewModel source)
	{
		var parameters = new
		{
			ApiUrl = source.ApiBetUrl,
			source.ApiKey,
			source.ApiToken,
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.tp.manual.bettime",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
