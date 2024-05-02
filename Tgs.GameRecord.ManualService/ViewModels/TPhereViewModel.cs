using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.TPhere.Common;

public record TPhereViewModel
{
	[Required]
	[DataType(DataType.Url)]
	public Uri ApiBetUrl { get; init; } = default!;
	[Required]
	public string ApiKey { get; init; } = default!;
	[Required]
	public string ApiToken { get; init; } = default!;
	[Required]
	[DataType(DataType.DateTime)]
	public DateTimeOffset StartTime { get; init; }
	[Required]
	[DataType(DataType.DateTime)]
	[DateTimeRange("StartTime", 30)]
	public DateTimeOffset EndTime { get; init; }
}
