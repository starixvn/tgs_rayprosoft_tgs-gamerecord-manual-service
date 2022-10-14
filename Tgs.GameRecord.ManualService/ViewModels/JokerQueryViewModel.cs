using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record JokerQueryViewModel()
{
    [Required]
    public string BrandCode { get; init; } = default!;
    [Required]
    public string AgentId { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 3600)]
    public DateTime EndTime { get; init; }
}
