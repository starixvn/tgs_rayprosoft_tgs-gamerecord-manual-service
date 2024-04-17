using System.Text;

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.ManualService.ViewModels;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.ManualService.Controllers;

[Route("Endor")]
[ApiController]
public class EndorphinaController : ControllerBase
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
	///             "apiUrl":"https://test.endorphina.network",
	///             "merchantId":"1494",
	///             "secretKey":"9BC9E97FFCD74B16B87BD6FA82C8C2AF",
	///             "token":"AA8BB60F5A134264BE838CF6EBA7C8F1"
	///         }
	/// </remarks>
	[HttpPost]
	public async ValueTask<GameRecorResultViewModel> GameRecordAsync(
		[FromServices] IMessageSender messageSender,
		EndorphinaQueryViewModel source)
	{
		var parameters = new
		{
			source.ApiUrl,
			source.MerchantId,
			source.SecretKey,
			source.Token
		};

		var readOnlyMemory = await messageSender.RequestAsync<ReadOnlyMemory<byte>, ReadOnlyMemory<byte>>(
			"gp.gamerecord.manual.endor",
			Encoding.UTF8.GetBytes(JsonSerializer.Serialize(parameters)),
			HttpContext.RequestAborted)
			.ConfigureAwait(false);

		return JsonSerializer.Deserialize<GameRecorResultViewModel>(Encoding.UTF8.GetString(readOnlyMemory.Span))!;
	}
}
