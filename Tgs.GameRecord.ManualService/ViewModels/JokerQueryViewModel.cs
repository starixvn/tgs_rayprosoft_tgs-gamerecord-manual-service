using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record JokerQueryViewModel()
{
    [Required]
    [DataType(DataType.Url)]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string AppId { get; init; } = default!;
    [Required]
    public string SecretKey { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 60)]
    public DateTimeOffset EndTime { get; init; }
}
