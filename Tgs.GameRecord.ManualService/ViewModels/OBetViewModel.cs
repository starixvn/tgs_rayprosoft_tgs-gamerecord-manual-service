using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record OBetViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string ApiKey { get; init; } = default!;
    [Required]
    public string AgentId { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRangeMinutes("StartTime", 15)]
    public DateTime EndTime { get; init; }
}
