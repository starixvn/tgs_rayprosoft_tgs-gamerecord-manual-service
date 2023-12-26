using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record Cards365ViewModel
{
    [Required]
    [DataType(DataType.Url)]
    public Uri ApiUrl { get; init; } = default!;

    [Required]
    public string Website { get; init; } = default!;

    [Required]
    public string Cert { get; init; } = default!;

    [Required]
    public string Extension1 { get; init; } = default!;

    [Required]
    public DateTimeOffset StartTime { get; init; }

    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 60)]
    public DateTimeOffset EndTime { get; init; }
}
