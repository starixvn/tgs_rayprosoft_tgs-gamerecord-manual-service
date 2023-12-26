using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record WicketCricketViewModel
{
    [Required]
    [DataType(DataType.Url)]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string Website { get; init; } = default!;
    [Required]
    public string Cert { get; init; } = default!;
    [Required]
    public string Agent { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset EndTime { get; init; }
}
