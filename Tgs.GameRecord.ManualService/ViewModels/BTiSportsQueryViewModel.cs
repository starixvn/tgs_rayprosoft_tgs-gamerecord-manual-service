using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record BTiSportsQueryViewModel
{
	[Required]
	[DataType(DataType.Url)]
	public Uri DataApiUrl { get; init; } = default!;
	[Required]
	public string AgentUserName { get; init; } = default!;
	[Required]
	public string AgentPassword { get; init; } = default!;
	[Required]
	[DataType(DataType.DateTime)]
	public DateTimeOffset StartTime { get; init; }
	[Required]
	[DataType(DataType.DateTime)]
	public DateTimeOffset EndTime { get; init; }
}
