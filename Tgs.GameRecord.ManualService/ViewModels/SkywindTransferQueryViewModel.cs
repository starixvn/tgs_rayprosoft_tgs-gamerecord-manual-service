using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record SkywindTransferQueryViewModel
{
    [Required]
    public Uri GameApiUrl { get; init; } = default!;
    [Required]
    public string SecretKey { get; init; } = default!;
    [Required]
    public string Username { get; init; } = default!;
    [Required]
    public string Password { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartDate", 600)]
    public DateTime EndDate { get; init; }
}
