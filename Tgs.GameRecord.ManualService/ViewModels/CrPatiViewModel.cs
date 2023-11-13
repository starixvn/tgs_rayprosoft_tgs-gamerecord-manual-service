using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record CrPatiViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;

    [Required]
    public string ApiKey { get; init; } = default!;

    [Required]
    public string ApiSecret { get; init; } = default!;

    [Required]
    public DateTime StartTime { get; init; }

    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRangeMinutes("StartTime", 120)]
    public DateTime EndTime { get; init; }
}
