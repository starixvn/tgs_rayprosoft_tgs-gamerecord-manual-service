using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record JDBTransferQueryViewModel
{
	[Required]
	[DataType(DataType.Url)]
	public Uri ApiUrl { get; init; } = default!;
	[Required]
	public string Domain { get; init; } = default!;
	[Required]
	public string AesKey { get; init; } = default!;
	[Required]
	public string AesIV { get; init; } = default!;
	[Required]
	public string Agent { get; init; } = default!;
	[Required]
	[DataType(DataType.DateTime)]
	public DateTimeOffset StartTime { get; init; }
	[Required]
	[DataType(DataType.DateTime)]
	[DateTimeRange("StartTime", 5)]
	public DateTimeOffset EndTime { get; init; }
}
