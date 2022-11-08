using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record SBOTransferQueryViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string CompanyKey { get; init; } = default!;
    [Required]
    public string Agent { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; init; }
}
