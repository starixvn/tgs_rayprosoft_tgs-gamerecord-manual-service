using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("9WCRICKET")]
[ApiController]
public class WicketCricketController : ControllerBase
{
	/// <summary>
	/// Games the record by bookmaker asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///         {
	///             "apiUrl": "https://apiinfo.cckk77.net/",
	///             "website": "WICKETSPRO",
	///             "cert": "wkVwQ8sMVr252EA9",
	///             "agent": "testpginrma",
	///             "startTime": "2023-09-27T00:00:00+08:00",
	///             "endTime": "2023-09-28T00:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("Bookmaker")]
	public ValueTask GameRecordByBookmakerAsync(
		[FromServices] IMessageSender messageSender,
		WicketCricketViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.Website,
			source.Cert,
			source.Agent,
			ReportType = "Bookmaker",
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.wicketCricket.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}

	/// <summary>
	/// Games the record by exchange asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///         {
	///             "apiUrl": "https://apiinfo.cckk77.net/",
	///             "website": "WICKETSPRO",
	///             "cert": "wkVwQ8sMVr252EA9",
	///             "agent": "zf055gpi",
	///             "startTime": "2023-09-27T00:00:00+08:00",
	///             "endTime": "2023-09-28T00:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("Exchange")]
	public ValueTask GameRecordByExchangeAsync(
		[FromServices] IMessageSender messageSender,
		WicketCricketViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.Website,
			source.Cert,
			source.Agent,
			ReportType = "Exchange",
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.wicketCricket.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}

	/// <summary>
	/// Games the record by fancy bet asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///         {
	///             "apiUrl": "https://apiinfo.cckk77.net/",
	///             "website": "WICKETSPRO",
	///             "cert": "wkVwQ8sMVr252EA9",
	///             "agent": "zf055gpi",
	///             "startTime": "2023-09-27T00:00:00+08:00",
	///             "endTime": "2023-09-28T00:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("FancyBet")]
	public ValueTask GameRecordByFancyBetAsync(
		[FromServices] IMessageSender messageSender,
		WicketCricketViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.Website,
			source.Cert,
			source.Agent,
			ReportType = "FancyBet",
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.wicketCricket.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}

	/// <summary>
	/// Games the record by sportsbook asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///         {
	///             "apiUrl": "https://apiinfo.cckk77.net/",
	///             "website": "WICKETSPRO",
	///             "cert": "wkVwQ8sMVr252EA9",
	///             "agent": "zf055gpi",
	///             "startTime": "2023-09-27T00:00:00+08:00",
	///             "endTime": "2023-09-28T00:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("Sportsbook")]
	public ValueTask GameRecordBySportsbookAsync(
		[FromServices] IMessageSender messageSender,
		WicketCricketViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.Website,
			source.Cert,
			source.Agent,
			ReportType = "Sportsbook",
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.wicketCricket.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
