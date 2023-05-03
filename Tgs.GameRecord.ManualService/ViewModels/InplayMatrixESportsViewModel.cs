using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record InplayMatrixESportsViewModel
{
    [Required]
    public Uri ReportUrl { get; init; } = default!;
    [Required]
    public string MerchantCode { get; init; } = default!;
    [Required]
    public string MerchantPrefix { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRangeDayAttribute("StartTime", 1)]
    public DateTime EndTime { get; init; }
}
