using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record VRGamingQueryViewModel
{
    [Required]
    public string BrandCode { get; init; } = default!;
    [Required]

    public DateTime StartTime { get; init; } = default!;
    [Required]

    public DateTime EndTime { get; init; } = default!;
}
