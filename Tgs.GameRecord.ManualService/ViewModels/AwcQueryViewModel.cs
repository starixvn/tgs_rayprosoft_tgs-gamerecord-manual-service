using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record AwcQueryViewModel
{
    [Required]
    public Uri GameRecordApiUrl { get; init; } = default!;
    [Required]
    public string GameProviderCode { get; init; } = default!;
    [Required]
    public string GameProviderAgentId { get; init; } = default!;
    [Required]
    public string GameProviderCert { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 3600)]
    public DateTime EndTime { get; init; }
}
