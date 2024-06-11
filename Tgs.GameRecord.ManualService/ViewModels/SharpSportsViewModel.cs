using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record SharpSportsViewModel
{
	[Required]
	[DataType(DataType.Url)]
	public Uri ApiUrl { get; init; } = default!;
	[Required]
	public string MerchantId { get; init; } = default!;
	[Required]
	public string ClientId { get; init; } = default!;
	[Required]
	public string ClientSecret { get; init; } = default!;
	[Required]
	[DataType(DataType.DateTime)]
	public DateTimeOffset StartTime { get; init; }
	[Required]
	[DataType(DataType.DateTime)]
	[DateTimeRangeDay("StartTime", 1)]
	public DateTimeOffset EndTime { get; init; }
}
