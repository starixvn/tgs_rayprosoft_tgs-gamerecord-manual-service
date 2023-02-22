using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record BTiSportsQueryViewModel
{
    [Required]
    public Uri TokenApiUrl { get; init; } = default!;
    [Required]
    public Uri OpenBetsApiUrl { get; init; } = default!;
    [Required]
    public Uri HistoryBetsPagingApiUrl { get; init; } = default!;
    [Required]
    public string AgentUserName { get; init; } = default!;
    [Required]
    public string AgentPassword { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; init; }
}
