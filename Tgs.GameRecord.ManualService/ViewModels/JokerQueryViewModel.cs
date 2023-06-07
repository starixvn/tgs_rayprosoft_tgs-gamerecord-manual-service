using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record JokerQueryViewModel()
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string AppId { get; init; } = default!;
    [Required]
    public string SecretKey { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRangeMinutes("StartTime", 60)]
    public DateTime EndTime { get; init; }
}
