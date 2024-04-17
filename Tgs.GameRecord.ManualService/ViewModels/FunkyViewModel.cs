using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public class FunkyViewModel
{
	[Required]
	[DataType(DataType.Url)]
	public Uri ApiReportUrl { get; init; } = default!;

	[Required]
	public string Authentication { get; init; } = default!;

	[Required]
	[DataType(DataType.DateTime)]
	[DateTimeRange("StartTime", 60)]
	public DateTimeOffset EndTime { get; init; }

	[Required]
	[DataType(DataType.DateTime)]
	public DateTimeOffset StartTime { get; init; }

	[Required]
	public string UserAgent { get; init; } = default!;
}
