using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record EvolutionTransferQueryViewModel
{
    [Required]
    public Uri GameApiUrl { get; init; } = default!;
    [Required]
    public string CasinoId { get; init; } = default!;
    [Required]
    public string GameHistoryApiToken { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartDate", 900)]
    public DateTime EndDate { get; init; }
}
