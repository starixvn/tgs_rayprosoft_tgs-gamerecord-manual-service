using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("sbotf")]
[ApiController]
public class SBOTransferController : ControllerBase
{
	/// <summary>
	/// Games the record by sports book asynchronous.
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
	///             "apiUrl": "https://ex-api-demo-yy.568win.com",
	///             "companyKey": "49ED28A987624CA0A3F834C3B8A69AAB",
	///             "agent": "STAG_GPI_CNY",
	///             "startTime": "2022-09-07T18:50:00+08:00",
	///             "endTime": "2022-09-07T18:55:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("sportsbook")]
	public ValueTask GameRecordBySportsBookAsync(
		[FromServices] IMessageSender messageSender,
		SBOTransferQueryViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.CompanyKey,
			source.Agent,
			Portfolio = "SportsBook",
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.sbotf.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}

	/// <summary>
	/// Games the record by virtual sports asynchronous.
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
	///             "apiUrl": "https://ex-api-demo-yy.568win.com",
	///             "companyKey": "49ED28A987624CA0A3F834C3B8A69AAB",
	///             "agent": "STAG_GPI_CNY",
	///             "startTime": "2022-09-22T16:30:00+08:00",
	///             "endTime": "2022-09-22T17:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("virtualsports")]
	public ValueTask GameRecordByVirtualSportsAsync(
		[FromServices] IMessageSender messageSender,
		SBOTransferQueryViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.CompanyKey,
			source.Agent,
			Portfolio = "VirtualSports",
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.sbotf.manual",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}

	/// <summary>
	/// Games the record by seamless game asynchronous.
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
	///             "apiUrl": "https://ex-api-demo-yy.568win.com",
	///             "companyKey": "49ED28A987624CA0A3F834C3B8A69AAB",
	///             "agent": "STAG_GPI_CNY",
	///             "startTime": "2022-09-22T16:30:00+08:00",
	///             "endTime": "2022-09-22T17:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("seamlessgame")]
	public ValueTask GameRecordBySeamlessGameAsync(
		[FromServices] IMessageSender messageSender,
		SBOTransferQueryViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.CompanyKey,
			source.Agent,
			Portfolio = "SeamlessGame",
			source.StartTime,
			source.EndTime
		};

		return messageSender.PublishAsync<ReadOnlyMemory<byte>>(
			subject: "gp.gamerecord.sbotf.manual.seamlessgame",
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			cancellationToken: HttpContext.RequestAborted);
	}
}
