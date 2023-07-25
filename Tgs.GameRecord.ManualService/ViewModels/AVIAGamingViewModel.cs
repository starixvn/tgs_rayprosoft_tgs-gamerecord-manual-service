using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record AVIAGamingViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string Authorization { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; init; }
}
