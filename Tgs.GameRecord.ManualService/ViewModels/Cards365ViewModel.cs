using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record Cards365ViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;

    [Required]
    public string Website { get; init; } = default!;

    [Required]
    public string Cert { get; init; } = default!;

    [Required]
    public string Extension1 { get; init; } = default!;

    [Required]
    public DateTime StartTime { get; init; }

    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRangeMinutes("StartTime", 60)]
    public DateTime EndTime { get; init; }
}
