using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record CrPatiViewModel
{
	[Required]
	[DataType(DataType.Url)]
	public Uri ApiUrl { get; init; } = default!;

	[Required]
	public string ApiKey { get; init; } = default!;

	[Required]
	public string ApiSecret { get; init; } = default!;

	[Required]
	public DateTimeOffset StartTime { get; init; }

	[Required]
	[DataType(DataType.DateTime)]
	[DateTimeRange("StartTime", 120)]
	public DateTimeOffset EndTime { get; init; }
}
